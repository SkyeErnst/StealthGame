using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(FieldOfView))]
public class FieldOfViewEditor : Editor
{
    void OnSceneGUI()
    {   
        FieldOfView fow = (FieldOfView)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fow.transform.position, Vector3.up, Vector3.forward, 360, fow.viewRadius);

        Vector3 viewAngleA = fow.DirFromAngle(-fow.viewAngle / 2, false);
        Vector3 viewAngleB = fow.DirFromAngle(fow.viewAngle / 2, false);

        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleA * fow.viewRadius);
        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleB * fow.viewRadius);

        Handles.color = Color.red;
        foreach(Transform visibleTarget in fow.visibleTargets)
        {
            Vector3 adjust = visibleTarget.position;
            adjust.y = adjust.y + 1.6f; //Offset to raycast to camera height roughly
            Handles.DrawLine(fow.transform.position, adjust);
        }

        Handles.color = Color.yellow;
        foreach(Transform perceptableTarget in fow.perceptableTargets)
        {
            Vector3 adjust = perceptableTarget.position;
            adjust.y = adjust.y + 1.6f;
            Handles.DrawLine(fow.transform.position, adjust);
        }
    }
}
