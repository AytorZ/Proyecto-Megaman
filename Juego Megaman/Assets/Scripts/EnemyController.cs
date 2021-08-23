using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    float damage = 1.0F;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Mega Man")
        {
            PlayerController controller = other.gameObject.GetComponent<PlayerController>();
            controller.TakeDamage(damage);
        }
    }
}
