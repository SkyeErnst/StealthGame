using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    
    public float viewRadius;
    [Range(0,360)]
    public float viewAngle;

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    public List<Transform> visibleTargets = new List<Transform>();
    public List<Transform> perceptableTargets = new List<Transform>();


    void Start() //Starts continuous looking w/ .2 second delay between search
    {
        StartCoroutine("FindTargetsWithDelay", .2f);
    }

    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true) //Continuous search loop
        {
            yield return new WaitForSeconds(delay);
            visibleTargets = new List<Transform>();
            perceptableTargets = new List<Transform>();
            FindTargets();
        }
    }

    public void FindTargets()
    {
        Collider[] targetsInPerceptionRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

        for(int i = 0; i < targetsInPerceptionRadius.Length; i++)
        {
            Transform target = targetsInPerceptionRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position); //Finds direction to target: Targets position - NPC's position
            dirToTarget.y = dirToTarget.y + 1.6f;
            if (!perceptableTargets.Contains(target)) perceptableTargets.Add(target); //If target was not perceptable before, add to list of perceptable targets
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2) // If target is within viewing angle, go to block vvv
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position); //Distance from target
                if (!Physics.Raycast(transform.position, dirToTarget, distanceToTarget, obstacleMask) && !visibleTargets.Contains(target)) visibleTargets.Add(target); //Raycast from NPC to target. If raycast is false and 
                // target is not in visible targets array. Add target to visible targets.
            }
        }
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if(!angleIsGlobal) angleInDegrees += transform.eulerAngles.y;
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
