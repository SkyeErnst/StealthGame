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
    public float Gravity = -9.81f;

    private Vector3 velocity;
    private bool isGrounded = false;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        // Check if we are grounded
        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);

        if(true == isGrounded && velocity.y < 0)
        {
            // Not setting this to zero to ensure that the player levels out on the floor
            velocity.y = -2f;
        }

        // Get x and y inputs from old input mapping
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Perform move
        Vector3 move = transform.right * x + transform.forward * z;
        Controller.Move(Speed * Time.deltaTime * move);

        // Jump logic
        if(Input.GetKeyDown(KeyCode.Space) && true == isGrounded)
        {
            velocity.y = Mathf.Sqrt(JumpHeight * -2f * Gravity);
        }

        // Apply Gravity
        velocity.y += Gravity * Time.deltaTime;
        Controller.Move(velocity * Time.deltaTime);
    }
}
