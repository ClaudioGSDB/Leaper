using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDash : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<PlayerMovement>().canDash = true;
            StartCoroutine(DisableDash());
        }
    }

    private IEnumerator DisableDash()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        transform.GetChild(0).gameObject.SetActive(false);
        //play some animation maybe

        yield return new WaitForSeconds(4);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
