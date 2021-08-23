using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GutsManController : MonoBehaviour
{
    [SerializeField]
    Transform target;

    [SerializeField]
    float wakeUpDistance = 3.0F;

    [SerializeField]
    float moveSpeed = 1.0F;

    Animator animator;


    public GameObject player;

    int health = 100;
    int awakeHash;

    float passiveCounter;
    float attackCounter;
    float backCounter;

    void setPassiveCounter()
    {
        passiveCounter = 3.0F;
    }

    void setAttackCounter()
    {
        attackCounter = 1.0F;
    }
    void setBackCounter()
    {
        backCounter = 1.0F;
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
        awakeHash = Animator.StringToHash("imActive");
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
        animator.SetBool("isAttacking", true);
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
            animator.SetBool("isAttacking", false);
            setPassiveCounter();
            setAttackCounter();
            setBackCounter();
        }
    }

    public void takeDamage(int damage)
    {
        health -= damage;
        if(health < 0) {
            Destroy(gameObject);
            player.GetComponent<PlayerController>().Win();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        takeDamage(20);
    }

}
