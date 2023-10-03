using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject respawnPoint;
    public GameObject player;
    public Animator animator;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DeathAnim());
        }
    }
    private IEnumerator DeathAnim()
    {

        player.GetComponent<PlayerMovement>().aliveTrig = false;

        yield return new WaitForSeconds(0.6f);

        player.transform.position = respawnPoint.transform.position;

        player.GetComponent<PlayerMovement>().aliveTrig = true;
    }

}
