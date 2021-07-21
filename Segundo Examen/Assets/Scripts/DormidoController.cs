using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DormidoController : MonoBehaviour 
{
    [SerializeField]
    Transform hero;

    float speed = 2F;
    Animator animator;

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
        Vector2 nextPosition = new Vector2(-8, -2.5F);
        Vector2 leftPosition = new Vector2(4, -2.5F);
        float distanceToHero = transform.position.x - hero.transform.position.x;
        if (distanceToHero <= 4)
        {
            animator.SetBool("awake", true);
            transform.position = Vector2.MoveTowards(transform.position, nextPosition, Time.deltaTime * speed);
        } else if (transform.position.x == nextPosition.x)
        {
            transform.position = Vector2.MoveTowards(transform.position, leftPosition, Time.deltaTime * speed);
        }
    }
}
