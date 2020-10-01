using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class land : MonoBehaviour
{

    public GameObject treesForCover;
    public GameObject theLand;
    public Toggle button;
    public string text;

    /**
     * changes the visability
     */
    public void SetSelectedLandVisabillity(bool visability)
    {
        this.gameObject.SetActive(visability);
        Debug.Log("visability " + visability);
    }
    
    /**
     * changes the land color
     */
    public void ChangeLandColor(Material color)
    {
        Debug.Log("change land color " + color);
        theLand.GetComponent<Renderer>().material = color;
    }

    /**
     * check if the radio button is on or not.
     */
    public bool GetButtonIsOn()
    {
        return button.isOn;
    }

    /**
     * get the text string for the land
     */
    public string GetText()
    {
        return text;
    }


}

