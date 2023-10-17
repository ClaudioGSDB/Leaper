using UnityEngine;

public class TriggerController : MonoBehaviour
{
    public Transform targetGameObject; // The GameObject to move
    public Vector3 targetPosition; // The position to move the target GameObject to

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Move the target GameObject to the specified position
            targetGameObject.position = targetPosition;
        }
    }
}
