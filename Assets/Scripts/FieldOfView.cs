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


    void Start()
    {
        StartCoroutine("FindTargetsWithDelay", .2f);
    }

    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
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
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if (!perceptableTargets.Contains(target)) perceptableTargets.Add(target);
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);
                if (!Physics.Raycast(transform.position, dirToTarget, distanceToTarget, obstacleMask) && !visibleTargets.Contains(target)) visibleTargets.Add(target);
            }
        }
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if(!angleIsGlobal) angleInDegrees += transform.eulerAngles.y;
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
