using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeathCounter : MonoBehaviour
{
    public TMP_Text deathText;
    public int deaths = 0;

    public void Start()
    {
        UpdatedeathsText();
    }

    public void UpdatedeathsText()
    {
        if (gameObject.GetComponent<PlayerMovement>().alive)
        {
            deathText.text = "Deaths " + deaths;
        }
    }

    public void increaseDeath()
    {
        deaths++;
        UpdatedeathsText();
    }
}
