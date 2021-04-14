using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables

    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed = 1f;

    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private Vector3 velocity;

    [SerializeField] private Animator animator;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;
    private bool isGrounded = false;

    [SerializeField] private float jumpHeight = 3f;

    int tapCount;

    #endregion

    void Update()
    {
        Move();
    }

    void LateUpdate()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            tapCount += 1;
            StartCoroutine(Countdown());
        }

        if (tapCount == 2)
        {
            tapCount = 0;
            StopCoroutine(Countdown());
            Jump();
        }
    }

    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(0.3f);
        tapCount = 0;
    }

    private void Move()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.acceleration.x * speed / 2;
        float z = 0f;

        if (Input.touchCount > 0)
        {
            z = 1f;
            animator.SetBool("RunRight", false);
            animator.SetBool("RunLeft", false);
            animator.SetBool("Run", true);
        }
        else
        {
            z = 0f;
            animator.SetBool("Run", false);
        }

        if (x < 0)
        {
            animator.SetBool("RunRight", false);
            animator.SetBool("RunLeft", true);
        }
        else if (x > 0)
        {
            animator.SetBool("RunLeft", false);
            animator.SetBool("RunRight", true);
        }
        else
        {
            animator.SetBool("RunRight", false);
            animator.SetBool("RunLeft", false);
            animator.SetBool("Run", false);
        }

        // MOVING
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // FALLING
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Jump()
    {
        if (isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
}
