using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : PsychicsObject
{
    [SerializeField]
    float maxSpeed = 5F;

    [SerializeField]
    float jumpTakeOffSpeed = 8F;

    Animator animator;

    SessionManagerController sessionManager;

    bool facingRight = true;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        sessionManager = SessionManagerController.GetInstancia() as SessionManagerController;
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;
        move.x = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && grounded)
        {
            animator.SetBool("IsJumping", true);
            velocity.y = jumpTakeOffSpeed;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                animator.SetBool("IsJumping", false);
                animator.SetBool("IsFalling", true);
                velocity.y = velocity.y * 0.5F;

            }
        }

        if (grounded)
        {
            animator.SetBool("IsFalling", false);
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

    //void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.gameObject.name == "Patrulla")
    //    {
    //        Debug.Log("Pego con patrulla");
    //    }
    //    else if(collision.gameObject.name == "Dormido")
    //    {
    //        Debug.Log("Pego con dormido");
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Patrulla")
        {
            sessionManager.doDamage(40);
            Debug.Log("Pego con patrulla");
        }
        else if (collision.gameObject.name == "Dormido")
        {
            Debug.Log("Pego con dormido");
        }
    }
}
