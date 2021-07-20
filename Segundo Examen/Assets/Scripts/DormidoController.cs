using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DormidoController : MonoBehaviour 
{
    [SerializeField]
    Transform hero;

    [SerializeField]
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
        Vector2 nextPosition = new Vector2(-8, -2.11F);
        if (hero.position.x >= 1 && hero.position.y <= -2.11)
        {
            animator.SetBool("awake", true);
            transform.position = Vector2.MoveTowards(transform.position, nextPosition, Time.deltaTime * speed);
        }
    }
}
