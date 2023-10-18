using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathCounter : MonoBehaviour
{
    public Text deathText;
    public int deaths = 0;

    public void Start()
    {
        UpdatedeathsText();
    }

    public void UpdatedeathsText()
    {

    }

    public void increaseDeath()
    {
        deaths++;
    }
}
