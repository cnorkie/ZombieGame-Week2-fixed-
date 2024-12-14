using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // Required for NavMeshAgent

public class Enemy : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float chaseSpeed = 3.5f; // Speed of the enemy
    public int health = 3; // Enemy health

    private NavMeshAgent agent; // NavMeshAgent for pathfinding

    void Start()
    {
        // Get the NavMeshAgent component
        agent = GetComponent<NavMeshAgent>();

        // Ensure NavMeshAgent is set up properly
        if (agent != null)
        {
            agent.speed = chaseSpeed; // Set movement speed
        }

        // Find the player if not assigned in the Inspector
        if (player == null && GameObject.FindGameObjectWithTag("Player") != null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Update()
    {
        if (player != null)
        {
            ChasePlayer();
        }
    }

    void ChasePlayer()
    {
        // Move towards the player's position
        if (agent != null)
        {
            agent.SetDestination(player.position);
        }
        else
        {
            // If NavMeshAgent is not used, manually move toward the player
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * chaseSpeed * Time.deltaTime;
        }
    }

    public void TakeDamage(int damageAmount = 1)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Optionally play death effects or sounds here
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(1);
            Destroy(collision.gameObject); // Destroy the bullet
        }
    }
}
