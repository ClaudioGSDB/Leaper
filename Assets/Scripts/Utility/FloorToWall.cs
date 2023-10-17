using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FloorToWall : MonoBehaviour
{
    public Tilemap tilemap;
    private int wallLayer = 7;
    private int floorLayer = 6;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            tilemap.gameObject.layer = wallLayer;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            tilemap.gameObject.layer = floorLayer;
        } 
    }
}
