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
    public float Gravity = -18;
    public float body_X;
    public float body_Y;
    public float body_Z;
    public float moveScalar;

    private Vector3 velocity;
    private Vector3 move;
    private bool isGrounded = false;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        // Check if we are grounded
        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);

        if(isGrounded == true && velocity.y < 0)
        {
            // Not setting this to zero to ensure that the player levels out on the floor
            velocity.y = -2;
        }

        // Get x and y inputs from old input mapping
        body_X = Input.GetAxis("Horizontal");
        body_Z = Input.GetAxis("Vertical");

        


        // Jump logic
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            velocity.y = Mathf.Sqrt(JumpHeight * -2 * Gravity);
        }

        //Check if shift key held down
        if(Input.GetKey(KeyCode.LeftShift) && isGrounded == true)
        {
            //Apply sprint if shift is down
            Controller.Move(MoveSpeed(moveScalar));
        }
        else
        {
            //regular movement
            Debug.Log("Regular Movement");
            Controller.Move(MoveSpeed());
        }

        // Apply Gravity
        velocity.y += Gravity * Time.deltaTime;
        Controller.Move(velocity * Time.deltaTime);
    }

    Vector3 MoveSpeed(float scalar = 1)
    {
        return ((Speed * Time.deltaTime * ( scalar * (transform.right * body_X + transform.forward * body_Z))));
    }
}
