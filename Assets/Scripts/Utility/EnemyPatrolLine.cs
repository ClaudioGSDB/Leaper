using UnityEngine;

public class EnemyPatrolLine : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float patrolSpeed = 2.0f;
    public float cornerPauseTime = 1.0f;
    public float rotationSpeed = 360.0f;

    private bool movingToB = true;
    private float currentPauseTime = 0.0f;

    void Update()
    {
        // Rotate at a constant rate
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);

        if (currentPauseTime > 0)
        {
            currentPauseTime -= Time.deltaTime;
            return;
        }

        Transform targetPoint = movingToB ? pointB : pointA;



        // Move towards target point
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, patrolSpeed * Time.deltaTime);

        // Check if close to target point and switch direction if necessary
        if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            movingToB = !movingToB;
            currentPauseTime = cornerPauseTime;
        }
    }
}
