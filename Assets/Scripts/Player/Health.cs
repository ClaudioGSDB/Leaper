using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth = 3; // The maximum number of health segments the player can have
    private int currentHealth; // The current number of health segments the player has
    public Image[] healthSegments; // An array of Image components representing the health segments in the UI

    void Start()
    {
        currentHealth = maxHealth; // Set the current health to the maximum at the start
    }

    // Function to take damage and update the health UI
    public void TakeDamage()
    {
        if (currentHealth > 0) // Check if the player still has health segments left
        {
            if (gameObject.GetComponent<PlayerMovement>().alive)
            {
                currentHealth--; // Reduce the current health by one segment
                healthSegments[currentHealth].enabled = false; // Disable the health segment in the UI
            }
        }
    }

    // Function to gain health and update the health UI
    public void GainHealth()
    {
        if (currentHealth < maxHealth) // Check if the player is not already at maximum health
        {
            healthSegments[currentHealth].enabled = true; // Enable the next health segment in the UI
            currentHealth++; // Increase the current health by one segment
        }
    }
}
