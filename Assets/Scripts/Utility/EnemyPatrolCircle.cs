using UnityEngine;

public class EnemyPatrolCircle : MonoBehaviour
{
    public Transform patrolCenter; // Drag the center of the block here
    public float patrolSpeed = 2.0f;
    public float patrolRadius = 5.0f;
    public float cornerPauseTime = 2.0f;

    private float currentAngle = 0.0f;
    private float currentPauseTime = 0.0f;

    void Update()
    {
        if (currentPauseTime > 0)
        {
            currentPauseTime -= Time.deltaTime;
            return;
        }

        currentAngle += patrolSpeed * Time.deltaTime;

        if (currentAngle >= 360.0f)
        {
            currentAngle = 0.0f;
            currentPauseTime = cornerPauseTime;
        }

        float angleInRadians = currentAngle * Mathf.Deg2Rad;
        float x = patrolCenter.position.x + Mathf.Cos(angleInRadians) * patrolRadius;
        float y = patrolCenter.position.y + Mathf.Sin(angleInRadians) * patrolRadius;

        transform.position = new Vector2(x, y);
    }
}