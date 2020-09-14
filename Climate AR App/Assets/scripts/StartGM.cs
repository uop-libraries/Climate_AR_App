using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * Handles the start of the application. Once the level is placed on the plane, then this script handles showing instructions and sounds. 
 */
public class StartGM : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject welcomePopup;
    public GameObject instructionsForPOI;
    public GameObject bubbles;
    public GameObject POIs;
    public GameObject sounds;
    void Start()
    {
        welcomePopup.SetActive(true);
        bubbles.SetActive(false);
        POIs.SetActive(false);
        sounds.SetActive(false);
        instructionsForPOI.SetActive(false);

    }

    /**close the welcome text
     * 
     */
    public void CloseWelcomePopUp()
    {
        welcomePopup.SetActive(false);

    }

    /**
     * called once the level is placed.
     */
    public void OpenInstructionsForPOI()
    {
        instructionsForPOI.SetActive(true);
    }

    /**close the instructions for the POIs and activate the POIs
     * 
     */
    public void CloseInstructionsForPOI()
    {
        instructionsForPOI.SetActive(false);
        POIs.SetActive(true);
    }

    /**start the sounds in the level
     * 
     */
    public void StartSounds()
    {
        sounds.SetActive(true);
    }
}
