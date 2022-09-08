using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    private const string ALERT_LEVEL_STATE_GROUP = "AlertLevel";

    public void Awake()
    {
        //AkSoundEngine.SetState(ALERT_LEVEL_STATE_GROUP, AlertStates.NoAlert.ToString());
        
    }

    enum AlertStates
    {
        NoAlert=0,
        FOF
    }
}
