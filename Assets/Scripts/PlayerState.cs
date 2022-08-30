using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    public float StealthFactor;

    void Update() 
    {
        //Get Light Level on Player

        //Get Movement Scalar, slowness of crouched state derived from movement scalar

        //Player "StealthFactor" is combination of light visibility, movement speed, crouchedness, jumping, etc.
        //StealthFactor should be between 0 and 1
        //0 is the most hidden a player can be
        //1 is visible to everyone 
    }
}