using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaManController : PhysicsObject
{
    [SerializeField]
    float maxSpeed = 1F;

    [SerializeField]
    float jumpTakeOffSpeed = 6F;

    Animator animator;
    bool facingRight = true;

    public Transform firePoint;
    public GameObject bulletPrefab;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    protected override void ComputeAttack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("isFiring", true);
            fire();
        }else if (Input.GetButtonUp("Fire1"))
        {
            animator.SetBool("isFiring", false);
        }
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
                transform.Rotate(0, 180F, 0);
            }
        }

        animator.SetFloat("Speed", Mathf.Abs(move.x));
        targetVelocity = move * maxSpeed;
    }

    public void fire()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
