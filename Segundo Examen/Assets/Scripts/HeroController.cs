using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : PsychicsObject
{
    [SerializeField]
    float maxSpeed = 5F;

    [SerializeField]
    float jumpTakeOffSpeed = 500F;

    Animator animator;

    bool facingRight = true;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;
        move.x = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && grounded)
        {
            animator.SetBool("isJumping", true);
            velocity.y = jumpTakeOffSpeed;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                animator.SetBool("isJumping", false);
                animator.SetBool("isFalling", true);
                velocity.y = velocity.y * 0.5F;

            }
        }

        if (grounded)
        {
            animator.SetBool("isFalling", false);
        }

        if (move.x != 0)
        {
            bool wasFacingRight = facingRight;
            facingRight = move.x > 0;

            if (wasFacingRight != facingRight)
            {
                Vector3 localScale = transform.localScale;
                localScale.x = -localScale.x;
                transform.localScale = localScale;
            }
        }

        animator.SetFloat("Speed", Mathf.Abs(move.x));
        targetVelocity = move * maxSpeed;
    }
}
