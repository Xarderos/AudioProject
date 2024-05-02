using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this to control the speed of the player
    public float rotationSpeed = 100f; // Adjust this to control the rotation speed of the player
    public Animator animator; // Reference to the Animator component

    void Update()
    {
        // Get input from the player
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;

        // Apply movement to the player
        transform.Translate(movement);

        // Check if the player is moving
        if (movement.magnitude > 0)
        {
            // Player is moving, set animation parameters accordingly
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsRunning", true);

            // Rotate the player slightly when moving left or right
            if (horizontalInput != 0)
            {
                float rotationAmount = horizontalInput * rotationSpeed * Time.deltaTime;
                transform.Rotate(Vector3.up, rotationAmount);
            }
        }
        else
        {
            // Player is not moving, set animation parameters accordingly
            animator.SetBool("IsIdle", true);
            animator.SetBool("IsRunning", false);
        }
    }
}
