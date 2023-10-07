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
        sr = GetComponent<SpriteRenderer>();
        state = 5;
        incName = "";
        incItem = -1;
    }

    public void Update()
    {
        
        if (incName != "")
        {
            objectsToMod = GameObject.FindGameObjectsWithTag(incName);
            ModObj(objectsToMod);
        }

        //Power Ups - Modify Character
        if (incItem == 5) //default - revert everything
        {
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
            newColor = new Color(red / 255.0f, green / 255.0f, blue / 255.0f);
            sr.color = newColor;
            if(gameobject){
                gameobject.GetComponent<Collider2D>().enabled = false;
            }
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

        }
        else if (incItem == 1)
        {

        }
        else if (incItem == 2)
        {

        }
        else if (incItem == 3)
        {

        }
        else if (incItem == 4)
        {

        }

/*        //Run at the end for reset
        incName = "";
        incItem = -1;*/
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
}
