using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    //GameObject player;
    public string itemName = "Item"; // Name of the item you want to collect.
    public int itemValue = 1; // Value or score associated with the item.

    public bool isCollected = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object is the player (you can use tags or layers for this).
        if (collision.CompareTag("Player") && !isCollected)
        {
            if(itemName == "BadgeCase")
            {
                GameObject.Find("Canvas").transform.Find("Pause Menu").transform.Find("BadgeCase").gameObject.SetActive(true);
                GameObject.Find("Canvas").GetComponent<PauseMenu>().badgeCase = true;
                CollectItem();
            }
            else
            {
                collision.GetComponent<Powers>().incName = itemName;
                collision.GetComponent<Powers>().incItem = itemValue;
                CollectItem();
            }
        }
    }

    private void CollectItem()
    {
        // Add the item to the player's inventory or perform any other collection logic.
        // You can also play a sound effect or particle effect here.
        // For this example, we'll simply destroy the item.
        Destroy(gameObject);

        // Optionally, you can update the player's score or inventory.
/*        player playerController = FindObjectOfType<Player>();
        if (playerController != null)
        {
            playerController.AddScore(itemValue);
        }*/

        isCollected = true;
    }
}
