using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingController : MonoBehaviour
{
    [SerializeField]
    float heal = 1.0F;

    [SerializeField]
    Transform item;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Mega Man")
        {
            PlayerController controller = other.gameObject.GetComponent<PlayerController>();
            controller.HealDamage(heal);
            Destroy(item.gameObject);
        }
    }
}
