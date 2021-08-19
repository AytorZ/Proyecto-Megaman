using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrullaController : PhysicsObject
{
    [SerializeField]
    GameObject sparkles;

    Animator animator;
    bool facingRight = false;
    bool toTheLeft = true;
    int distanceCout = 400;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(toTheLeft)
        {
            distanceCout--;
            targetVelocity.x = -2F;
        }
        else
        {
            distanceCout--;
            targetVelocity.x = 2F;
        }

        if(distanceCout == 0)
        {
            toTheLeft = !toTheLeft;
            distanceCout = 500;
        }

        if (targetVelocity.x != 0)
        {
            bool wasFacingRight = facingRight;
            facingRight = targetVelocity.x < 0;

            if (wasFacingRight != facingRight)
            {
                Vector3 localScale = transform.localScale;
                localScale.x = -localScale.x;
                transform.localScale = localScale;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(sparkles, transform.position, transform.rotation);
        Destroy(gameObject);
    }

}
