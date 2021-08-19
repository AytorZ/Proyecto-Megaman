using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 1.0F;

    [SerializeField]
    bool isFacingRight = false;

    [SerializeField]
    float distanceToGround = 0.65F;

    [SerializeField]
    Transform[] groundPoints;

    Vector2 direction;

    void Start()
    {
        direction =
            isFacingRight
                ? Vector2.right
                : Vector2.left;
    }

    void Update()
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime);
        foreach (Transform groundPoint in groundPoints)
        {
            RaycastHit2D raycast = Physics2D.Raycast(groundPoint.position, Vector2.down, distanceToGround);
            if (!raycast.collider)
            {
                transform.eulerAngles = new Vector3(0, isFacingRight ? 0 : 180, 0);
                isFacingRight = !isFacingRight;
                break;
            }
        }
    }
}
