using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject respawnPoint;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject.Find("Player").GetComponent<Health>().TakeDamage();
            StartCoroutine(DeathAnim());
        }
    }
    private IEnumerator DeathAnim()
    {

        GameObject.Find("Player").GetComponent<PlayerMovement>().aliveTrig = false;
        GameObject.Find("Player").GetComponent<PlayerMovement>().speed = 0;
        yield return new WaitForSeconds(0.6f);

        GameObject.Find("Player").transform.position = respawnPoint.transform.position;

        GameObject.Find("Player").GetComponent<PlayerMovement>().aliveTrig = true;
        GameObject.Find("Player").GetComponent<PlayerMovement>().speed = 6f;
    }

}
