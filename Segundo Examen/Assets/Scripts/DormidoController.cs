using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DormidoController : PsychicsObject
{
    [SerializeField]
    Transform hero;

    Animator animator;
    bool facingRight = true;
    bool toTheLeft = true;
    int distanceCout = 3000;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float distanceToHero = transform.position.x - hero.transform.position.x;
        if (distanceToHero <= 4)
        {
            animator.SetBool("awake", true);
            if (toTheLeft)
            {
                distanceCout--;
                targetVelocity.x = -2F;
            }
            else
            {
                distanceCout--;
                targetVelocity.x = 2F;
            }

            if (distanceCout == 0)
            {
                toTheLeft = !toTheLeft;
                distanceCout = 1000;
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
    }
}
