using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController Controller;
    public Transform GroundCheck;

    public float GroundDistance;
    public float JumpHeight;
    public LayerMask GroundMask;


    public float Speed;
    public float Gravity = -18f;
    public float body_X;
    public float body_Y;
    public float body_Z;


    private float moveScalar = 1f;
    private float crouchScalar = 0.6f;
    private bool isCrouched = false;
    private const float moveScalarUpperLimit = 1.8f;
    private const float moveScalarLowerLimit = 1f;

    private float standingHeight = 1.7f;
    private float crouchedHeight = 1.7f / 2f;
    private Vector3 move;
    private bool isGrounded = false;
    private float TransitionMovementSmoothing;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        // Check if we are grounded
        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);

        if(isGrounded == true && move.y < 0)
        {
            // Not setting this to zero to ensure that the player levels out on the floor
            move.y = -2;
        }

        // Get x and y inputs from old input mapping
        body_X = Input.GetAxis("Horizontal");
        body_Z = Input.GetAxis("Vertical");

        // Jump logic
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            move.y = Mathf.Sqrt(JumpHeight * -2 * Gravity);
        }

        switch (Input.GetKeyDown(KeyCode.LeftControl))
        {
            case true:
                isCrouched = isCrouched ? false : true;
                break;
            case false:
                break;
        }

        switch (Input.GetKey(KeyCode.LeftShift))
        {
            case true:
                Run();
                break;
            case false:
                Walk();
                break;
        }

        switch (isCrouched)
        {
            case true:
                Crouch();
                Controller.Move(MoveSpeed((moveScalar*crouchScalar)));
                break;
            case false:
                Stand();
                Controller.Move(MoveSpeed(moveScalar));
                break;
        }

        //Update Gravity
        move.y += Gravity * Time.deltaTime;
        Controller.Move(move * Time.deltaTime);
    }

    //Formula returns movement speed for the controller
    Vector3 MoveSpeed(float scalar = 1)
    {
        return ((Speed * Time.deltaTime * ( scalar * (transform.right * body_X + transform.forward * body_Z))));
    }

    void Void()
    {}

    void Run()
    {
        if (moveScalar < moveScalarUpperLimit) moveScalar += 0.05f;
    }
    

    void Walk()
    {
        if (moveScalar > moveScalarLowerLimit) moveScalar -= 0.05f;
    }


    void Crouch()
    {
        if (Controller.height > crouchedHeight) Controller.height -= 0.01f;
    }

    void Stand()
    {
        if (Controller.height < standingHeight) Controller.height += 0.01f;
    }

}
