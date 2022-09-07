using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float MouseSensitivity;
    public float currMouseX;
    public float currMouseY;
    public float prevMouseX = 1;
    public float prevMouseY = 1;



    public bool firstFrame = true;

    public Transform PlayerBody;
    public Transform PlayerCam;


    private float xRot = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;    
    }

    // Update is called once per frame
    void Update()
    {
        currMouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        currMouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;
        
        //Pass over update if mouse hasn't moved
        if (currMouseX != prevMouseX || currMouseY != prevMouseY)
        {
            PlayerBody.Rotate(Vector3.up, currMouseX);

            xRot -= currMouseY;
            xRot = Mathf.Clamp(xRot, -90, 90);

            transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        }

        
        prevMouseX = currMouseX;
        prevMouseY = currMouseY;
    }
}
