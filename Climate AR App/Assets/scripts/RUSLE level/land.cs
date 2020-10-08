using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/** deal with RUSLE and holds the info of the land
 *  this script is place on each land style (sloped, flat etc)
 *  often called by landGM
 */
public class land : MonoBehaviour
{

    public GameObject treesForCover; //called and used by landGM in SetVisabilityOfTreesForAllLands()
    public GameObject[] theLand;
    public Toggle button;
    public string text; // the text that shows up after the user selects the land

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
        for (int i = 0; i < theLand.Length; i++)
        {
            theLand[i].GetComponent<Renderer>().material = color;
        }
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

