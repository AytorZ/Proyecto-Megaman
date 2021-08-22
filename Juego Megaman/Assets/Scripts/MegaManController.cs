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

    int walkingHash;
    int jumpingHash;
    int fallingHash;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        walkingHash = Animator.StringToHash("Speed");
        jumpingHash = Animator.StringToHash("isJumping");
        fallingHash = Animator.StringToHash("isFalling");
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
            animator.SetBool(jumpingHash, true);
            velocity.y = jumpTakeOffSpeed;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            animator.SetBool(fallingHash, true);
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5F;
            }
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

        if (grounded)
        {
            animator.SetBool(jumpingHash, false);
            animator.SetBool(fallingHash, false);
            animator.SetFloat(walkingHash, Mathf.Abs(move.x));
        }
        else
        {
            animator.SetBool(jumpingHash, true);
            if (velocity.y < -0.01)
            {
                animator.SetBool(fallingHash, true);
            }
        }
    }

    public void fire()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
