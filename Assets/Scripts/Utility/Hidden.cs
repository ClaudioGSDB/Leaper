using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapCollisionController : MonoBehaviour
{
    public Tilemap tilemap; // Reference to the Tilemap
    public float transparency = 0.5f; // The transparency value to set

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //
            // Get the TilemapRenderer component
            TilemapRenderer tilemapRenderer = tilemap.GetComponent<TilemapRenderer>();

            // Change the tilemap's transparency
            tilemapRenderer.material.color = new Color(1f, 1f, 1f, transparency);
        }
    }
}