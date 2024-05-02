using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController cc;
    public float speed = 3f;

    public float Gravity = -9.81f;
    public Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask floorMask;
    bool isGrounded;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public Transform cam;
    public Animator animator;
    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }
    void Update()
    {
        //Movimiento
        float horizontal = -Input.GetAxisRaw("Horizontal");
        float vertical = -Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
        animator.SetBool("IsIdle", true);
        animator.SetBool("IsRunning", false);

        if (direction.magnitude >= 0.1f)
        {
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsRunning", true);

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0, angle, 0);

            Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            cc.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        //Detección de suelo
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, floorMask);
        //Gravedad
        velocity.y += Gravity * Time.deltaTime;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -1.86f;
        }
        cc.Move(velocity * Time.deltaTime);
        //Salto
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(3 * -2 * Gravity);
        }

    }

}
