using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentAI : MonoBehaviour
{

    //Imported Classes
    public PlayerControl playerControl;
    public PlayerState playerState;

    //Agent attributes
    private Vector3 goal;
    private NavMeshAgent agent;
    public FieldOfView sight;


    //Skill check
    public float spottingCheck;
    public float spottingSkill = 0.3f;
    public bool playerIsSpotted = false;
    public float framesSinceSpotted = 1200;
    public int alertState = 0; // 0 => unalerted, 1 => heightened (after loosing player), 2 => alerted
    public int task = 0; // 0 => stationary, 1 => move to hard waypoint, 2 => moving along hard patrol, 3 => investigating, 4 => move to last player location, 5 => follow player 
    private const float agentSpeedUpperLimit = 3f;
    private const float agentSpeedLowerLimit = 2f;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {

        sight.FindTargets();
        spottingCheck = playerState.StealthFactor;

        //Sound Perception for modifying player detection
        switch (sight.perceptableTargets.Contains(playerControl.PlayerBody))
        {
            case true:
                break;
            case false:
                spottingCheck *= 0.5f;
                break;
        }

        //Visual Perception for modifying player detection
        switch (sight.visibleTargets.Contains(playerControl.PlayerBody))
        {
            case true:
                break;
            case false:
                spottingCheck *= 0.3f;
                break;
        }
        

        //Check if player is spotted and update frames since last spotted
        playerIsSpotted = (spottingSkill < (spottingCheck)) ? true : false;
        if (framesSinceSpotted <= 1200) 
        {
            framesSinceSpotted += 0.10f;
            if (framesSinceSpotted <= 0.20f) 
            {
                goal = playerControl.PlayerBody.position;
            }

        }

        //Changes alert level of the NPC based on playerSpotted and time since playerSpotted went to false.
        switch (playerIsSpotted)
        {
            case true:
                alertState = 2;
                framesSinceSpotted = 0;
                break;
            case false:
                if (framesSinceSpotted < 1200) 
                {
                    alertState = 1;
                }
                else
                {
                    alertState = 0;
                }
                break;
        }

        //alertState decides NPC behavior.
        switch (alertState)
        {
            case 0:     // At 0, AI should return to its default routine (static position or patrol)
                switch (task)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    default:
                        agent.destination = agent.transform.position;
                        break;
                }
                break;
            case 1:     // At 1, AI should move to the last known player location. If they have moved there, the AI should investigate the area. If it is simply alerted by some other means it should investigate the area. (Also useful for noise alert but not visual alert of player location.)
                if (goal != agent.transform.position)
                {
                    task = 4;
                }
                else
                {
                    goal = agent.transform.position;
                    task = 3;
                }
                
                switch (task)
                {
                    case 3:
                        RandomPathing();
                        break;
                    case 4:
                        agent.destination = goal;
                        break;
                    default:
                        agent.destination = agent.transform.position;
                        break;
                }
                break;
            case 2:     // At 2, AI is fully alert of player location, moves to player's current location.
                agent.destination = playerControl.PlayerBody.position;
                break;
        }

        
    }

    void Run()
    {
        if (agent.speed < agentSpeedUpperLimit) agent.speed += 0.05f;
    }

    void Walk()
    {
        if (agent.speed > agentSpeedLowerLimit) agent.speed -= 0.05f;
    }

    void RandomPathing()
    {
        float x_origin;
        float y_origin;
        float z_origin;

        x_origin = agent.transform.position.x;
        z_origin = agent.transform.position.z;
        y_origin = agent.transform.position.y;

        Vector3 randomPosition = new Vector3(UnityEngine.Random.Range(x_origin - 15, x_origin + 15),  UnityEngine.Random.Range(y_origin, y_origin), UnityEngine.Random.Range(z_origin - 15, z_origin + 15));
        agent.destination = randomPosition;
    }
}
