using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void TakeDamage()
    {
        // Handle enemy death, you could add more effects like playing sound or animations
        Die();
    }

    void Die()
    {
        // Destroy the enemy game object
        Destroy(gameObject);
    }

    // Optional: You can also handle collision directly here if the enemy should detect bullets on its own
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage();
        }
    }
}
