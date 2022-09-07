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
    private Transform goal;
    private NavMeshAgent agent;
    public FieldOfView sight;

    //Skill check
    public float spottingSkill = 0.6f;
    public bool playerIsSpotted = false;
    private const float agentSpeedUpperLimit = 3f;
    private const float agentSpeedLowerLimit = 2f;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {

        sight.FindTargets();

        switch (sight.perceptableTargets.Contains(playerControl))
        {
            
        }

        switch (playerIsSpotted)
            {
                case true:
                    agent.destination = playerControl.PlayerBody.position;
                    Run();
                    break;
                case false:
                    agent.destination = agent.transform.position;
                    Walk();
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
}
