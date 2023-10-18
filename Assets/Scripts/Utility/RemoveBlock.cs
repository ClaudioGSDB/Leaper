using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBlock : MonoBehaviour
{
    private PauseMenu canvas;
    private void Start()
    {
        canvas = GameObject.Find("Canvas").GetComponent<PauseMenu>();
    }
    // Update is called once per frame
    void Update()
    {
        if (canvas.badgeCase && canvas.caveB) 
        {
            Destroy(gameObject);
        }
    }
}
