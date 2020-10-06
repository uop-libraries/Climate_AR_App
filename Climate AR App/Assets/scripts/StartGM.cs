using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vuforia;

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
    public GameObject plane;
    bool doOnceFlag; //used to show instructions once at the start of the scene.
    void Start()
    {
        welcomePopup.SetActive(true);
        if (bubbles != null)
        {
            bubbles.SetActive(false);

        }
        POIs.SetActive(false);
        instructionsForPOI.SetActive(false);
        doOnceFlag = true;
    }

    /**close the welcome text
     * 
     */
    public void CloseWelcomePopUp()
    {
        welcomePopup.SetActive(false);

    }

    public void OpenWelcomePopUp()
    {
        welcomePopup.SetActive(true);

    }

    /**
     * called once the level is placed.
     */
    public void OpenInstructionsForPOI()
    {
        if (doOnceFlag)
        {
            instructionsForPOI.SetActive(true);
            doOnceFlag = false;
        }
    }

    /**close the instructions for the POIs and activate the POIs
     * 
     */
    public void CloseInstructionsForPOI()
    {
        instructionsForPOI.SetActive(false);
        POIs.SetActive(true);
    }

    /**
     *  called by button. the scene is also changed in pop up handler
     */
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("mainMenu");

    }

    /**
     * handles the logic to hide the plane when the level is placed. called by placements and button
     */
    public void SetActivePanelStartGM(bool setActive)
    {
        plane.GetComponent<AnchorInputListenerBehaviour>().enabled = setActive;
        plane.GetComponent<PlaneFinderBehaviour>().enabled = setActive;
    }
    /** DEPRECATED AudioGM script exists
     * 
     * sets the sounds active or not depending on passed in parameter. 
     */
    // public void ToggleSounds(bool soundOn)
    // {
    //   sounds.SetActive(soundOn);
    //}


}
