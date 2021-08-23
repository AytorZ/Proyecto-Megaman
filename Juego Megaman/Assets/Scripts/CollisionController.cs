using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    [SerializeField]
    Transform character;

    void OnCollisionEnter2D(Collision2D other)
    {
        /*
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Destroy(character.gameObject);
        }*/
    }
}
