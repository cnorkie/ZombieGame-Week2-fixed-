using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    // Variables for controlling the door
    public float doorSpeed = 3.0f;

    private bool playerNearby = false;
    private bool isOpen = false;

    // Reference to the MeshRenderer component to hide/show the door
    private MeshRenderer doorRenderer;
    private Collider doorCollider;

    private void Start()
    {
        // Get the MeshRenderer and Collider components of the door
        doorRenderer = GetComponent<MeshRenderer>();
        doorCollider = GetComponent<Collider>();
    }

    private void Update()
    {
        // Check if the player is nearby and presses the "F" key
        if (playerNearby && Input.GetKeyDown(KeyCode.F))
        {
            if (!isOpen)
            {
                OpenDoor();
            }
            else
            {
                CloseDoor();
            }
        }
    }

    private void OpenDoor()
    {
        isOpen = true;
        // Disable the door's visuals and collider
        doorRenderer.enabled = false;
        doorCollider.enabled = false;
    }

    private void CloseDoor()
    {
        isOpen = false;
        // Re-enable the door's visuals and collider
        doorRenderer.enabled = true;
        doorCollider.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Detect if the player enters the trigger zone
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Detect if the player exits the trigger zone
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }
}
