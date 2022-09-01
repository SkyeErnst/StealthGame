using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{

    public PlayerControl playerControl;
    public PlayerState playerState;

    private Transform goal;
    private NavMeshAgent agent;


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

    playerIsSpotted = (spottingSkill < playerState.StealthFactor) ? true : false;  

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
