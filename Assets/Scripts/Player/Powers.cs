using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powers : MonoBehaviour
{
    public int state;
    bool[] badges = { false, false, false, false, false };

    public string incName;
    public int incItem;

    private int red;
    private int green;
    private int blue;
    private Color newColor;
    private SpriteRenderer sr;

    private GameObject[] objectsToMod;

    public GameObject player;
    Rigidbody2D rb;
    PlayerMovement mov;
    //Water
    public float waterSpeedMultiplier;

    /*
     * Badges:
     * 0 - Cave
     * 1 - Forest
     * 2 - Desert
     * 3 - Water
     * 4 - Fire
     * 
     * powers:
     * 5 - Default
     * 6 - Cave
     * 7 - Forest
     * 8 - Water
     * 9 - Fire
     * 10 - Desert
     * 11 - Dark
    */

    private void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
        mov = player.GetComponent<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();
        waterSpeedMultiplier = 0.5f;
        state = 5;
        incName = "";
        incItem = -1;
        ChangeColor(255, 255, 255);
    }

    public void Update()
    {
        if (!mov.alive)
        {
            return;
        }
        if (mov.canDash)
        {
            sr.color = newColor;
        }
        else
        {
            sr.color = newColor * 0.6f;
        }
        
        if (incName != "")
        {
            objectsToMod = GameObject.FindGameObjectsWithTag(incName);
            ModObj(objectsToMod);
        }

        //Power Ups - Modify Character
        if (incItem == 5) //default - revert everything
        {
            state = 5;
            red = 0;
            green = 0;
            blue = 0;
            ChangeColor(red, green, blue);
            RevertObj(objectsToMod);
        }
        else if (incItem == 6)
        {

        }
        else if (incItem == 7)
        {

        }
        else if (incItem == 8) // Water
        {
            state = 8;
            red = 80;
            green = 180;
            blue = 255;
            ChangeColor(red, green, blue);
        }
        else if (incItem == 9)
        {

        }
        else if (incItem == 10)
        {

        }
        else if (incItem == 11)
        {

        }


        //Badge System
        if (incItem == 0)
        {
            GameObject.Find("Canvas").transform.Find("Pause Menu").transform.Find("Badges").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("Pause Menu").transform.Find("Badges").transform.Find("CaveB").gameObject.SetActive(true);
            GameObject.Find("Canvas").GetComponent<PauseMenu>().caveB = true;
        }
        else if (incItem == 1)
        {
            GameObject.Find("Canvas").transform.Find("Pause Menu").transform.Find("Badges").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("Pause Menu").transform.Find("Badges").transform.Find("ForestB").gameObject.SetActive(true);
            GameObject.Find("Canvas").GetComponent<PauseMenu>().forestB = true;
            GameObject teleporters = GameObject.Find("Teleporters");
            foreach (Transform child in teleporters.transform)
            {
                child.gameObject.SetActive(true);
            }
            //GameObject.Find("Portal").GetComponent<SpriteRenderer>().enabled = true;
        }
        else if (incItem == 2)
        {
            GameObject.Find("Canvas").transform.Find("Pause Menu").transform.Find("Badges").gameObject.SetActive(true);
        }
        else if (incItem == 3)
        {
            GameObject.Find("Canvas").transform.Find("Pause Menu").transform.Find("Badges").gameObject.SetActive(true);
        }
        else if (incItem == 4)
        {
            GameObject.Find("Canvas").transform.Find("Pause Menu").transform.Find("Badges").gameObject.SetActive(true);
        }

/*        //Run at the end for reset
        incName = "";
        incItem = -1;*/
    }

    private void ChangeColor(float red, float green, float blue)
    {
        newColor = new Color(red / 255.0f, green / 255.0f, blue / 255.0f);
        sr.color = newColor;
    }

    //Modify Objects
    private void ModObj(GameObject[] objectsToMod)
    {
        if (objectsToMod.Length > 0)
        {
            foreach (GameObject obj in objectsToMod)
            {
                if (incName == "Water")
                {
                    obj.GetComponent<PolygonCollider2D>().enabled = true;
                    obj.GetComponent<BoxCollider2D>().enabled = false;
                }
            }
        }
    }

    //Revert Objects modification when default
    private void RevertObj(GameObject[] objectsToMod)
    {
        if (objectsToMod.Length > 0)
        {
            foreach (GameObject obj in objectsToMod)
            {
                if (incName == "WaterPow")
                {
                    obj.GetComponent<PolygonCollider2D>().enabled = false;
                    obj.GetComponent<BoxCollider2D>().enabled = true;
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (state == 8 && collision.CompareTag("Water"))
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -mov.speed * waterSpeedMultiplier, float.MaxValue));
        }
    }  
}
