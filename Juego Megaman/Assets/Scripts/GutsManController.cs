using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GutsManController : PhysicsObject
{
    [SerializeField]
    Transform target;

    [SerializeField]
    float wakeUpDistance = 3.0F;

    [SerializeField]
    float moveSpeed = 1.0F;

    Animator animator;

    int attackHash;
    int awakeHash;

    float passiveCounter;
    float attackCounter;
    float backCounter;

    void setPassiveCounter()
    {
        passiveCounter = 3F;
    }

    void setAttackCounter()
    {
        attackCounter = 1F;
    }
    void setBackCounter()
    {
        backCounter = 3F;
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
        awakeHash = Animator.StringToHash("imActive");
        attackHash = Animator.StringToHash("isAttacking");
        setPassiveCounter();
        setAttackCounter();
        setBackCounter();
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, target.position);
        bool isAwake = distance <= wakeUpDistance;

        animator.SetBool(awakeHash, isAwake);
     
        if (isAwake)
        {
            passiveCounter -= Time.deltaTime;
            if (passiveCounter < 0)
            {
                attack();
            }
        }
        
    }

    private void attack()
    {
        animator.SetBool(attackHash, true);
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        attackCounter -= Time.deltaTime;
        if(attackCounter < 0)
        {
            back();
        }
    }

    private void back()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        backCounter -= Time.deltaTime;
        if(backCounter < 0)
        {
            animator.SetBool(attackHash, false);
            setPassiveCounter();
            setAttackCounter();
            setBackCounter();
        }
    }
}
