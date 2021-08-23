using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrullaController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 1.0F;

    [SerializeField]
    bool isFacingRight = true;
    [SerializeField]
    int distanceCout = 1500;

    Animator animator;
    bool toTheLeft = true;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        Vector3 position = Vector3.zero;
        bool wasFacingRight = isFacingRight;

        if (toTheLeft)
        {
            distanceCout--;
            isFacingRight = false;
            position = Vector3.right * moveSpeed * Time.deltaTime;
        }
        else
        {
            distanceCout--;
            isFacingRight = true;
            position = Vector3.left * moveSpeed * Time.deltaTime;
        }

        if(distanceCout == 0)
        {
            toTheLeft = !toTheLeft;
            distanceCout = 1500;
        }

        if (wasFacingRight != isFacingRight)
        {
            Vector3 localScale = transform.localScale;
            localScale.x = -localScale.x;
            transform.localScale = localScale;
        }
        transform.Translate(position);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

}
