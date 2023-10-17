using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Float : MonoBehaviour
{
    public float floatSpeed = 1.0f; // Adjust this to control the float speed.
    public float floatHeight = 0.1f; // Adjust this to control the float height.

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        // Calculate the new Y position based on a sine wave.
        float newY = initialPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;

        // Update the object's position with the new Y value.
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
