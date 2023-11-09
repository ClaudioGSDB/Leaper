using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Draw : MonoBehaviour
{

    public Tilemap tilemap;
    public CompositeCollider2D compositeCollider;

    // Update is called once per frame
    void Update()
    {
        tilemap = GetComponent<Tilemap>();
        compositeCollider = GetComponent<CompositeCollider2D>();

        if (tilemap != null && compositeCollider != null)
        {
            int pathCount = compositeCollider.pathCount;
            
            for (int i = 0; i < pathCount; i++)
            {
                int pointCount = compositeCollider.GetPathPointCount(i);
                Vector2[] points = new Vector2[pointCount];
                
                compositeCollider.GetPath(i, points);
                
                for (int j = 0; j < pointCount; j++)
                {
                    Vector3Int startCell = Vector3Int.FloorToInt((Vector3)points[j]);
                    Vector3Int endCell = Vector3Int.FloorToInt((Vector3)points[(j + 1) % pointCount]);
                    Vector3 startPoint = tilemap.CellToWorld(startCell);
                    Vector3 endPoint = tilemap.CellToWorld(endCell);
                    
                    Debug.DrawLine(startPoint, endPoint, Color.red, 1.0f);
                }
            }
        }
    }
}
