using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Check if we hit an enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Call TakeDamage on the enemy
            collision.gameObject.GetComponent<Enemy>()?.TakeDamage();
        }

        // Destroy the bullet when it hits something
        Destroy(gameObject);
    }
}
