using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class landGM : MonoBehaviour
{
    public GameObject flatLand;
    public GameObject slopeLand;
    public GameObject steepSlopeLand;
    public Material goodSoilColor;
    public Material badSoilColor;

    private bool healthyTopsoilSelectedFlag; //make sure the radio toggle button is checked in scene mode
    private bool isCoveredFlag;
    private GameObject currentSelectedObject;
    private GameObject soilProfile;
    private string childPathName;
    private Material currentSoilProfileColor;

    private GameObject soilProfileFlat;
    private GameObject soilProfileSlope;
    private GameObject soilProfileSteepSlope;
    // Start is called before the first frame update
    void Start()
    {
        healthyTopsoilSelectedFlag = true;
        isCoveredFlag = true;
        currentSelectedObject = flatLand;
        childPathName = "soil profile";
        soilProfileFlat = flatLand.transform.Find(childPathName).gameObject;
        soilProfileSlope = slopeLand.transform.Find(childPathName).gameObject;
        soilProfileSteepSlope = steepSlopeLand.transform.Find(childPathName).gameObject;
        if (soilProfileFlat == null || soilProfileSlope == null || soilProfileSteepSlope == null)
        {
            Debug.LogError("unable to find child " + childPathName);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FlatSelected()
    {
        Debug.Log("flatLand.GetComponent<land>().GetButtonIsOn() " + flatLand.GetComponent<land>().GetButtonIsOn());
        //need to check if the box is already checked
        if (flatLand.GetComponent<land>().GetButtonIsOn()) 
        {
            Debug.Log("flatland button is not active");
            flatLand.GetComponent<land>().SetSelectedLandVisabillity(true);
            currentSelectedObject = flatLand;
        }
        else
        {
            Debug.Log("flatland button is  active");
            flatLand.GetComponent<land>().SetSelectedLandVisabillity(false);

        }

    }

    public void SlopeSelected()
    {
        Debug.Log("slopeLand.GetComponent<land>().GetButtonIsOn() " + flatLand.GetComponent<land>().GetButtonIsOn());
        if (slopeLand.GetComponent<land>().GetButtonIsOn())
        {
            Debug.Log("slopeLand button is not active");
            slopeLand.GetComponent<land>().SetSelectedLandVisabillity(true);
            currentSelectedObject = slopeLand;
        }
        else
        {
            slopeLand.GetComponent<land>().SetSelectedLandVisabillity(false);
            Debug.Log("slopeLand button is  active");

        }
    }

    public void SteepSlopeSelected()
    {
        Debug.Log("steepSlopeLand.GetComponent<land>().GetButtonIsOn() " + flatLand.GetComponent<land>().GetButtonIsOn());
        if (steepSlopeLand.GetComponent<land>().GetButtonIsOn())
        {
            Debug.Log("steepSlopeLand button is not active");
            steepSlopeLand.GetComponent<land>().SetSelectedLandVisabillity(true);
            currentSelectedObject = steepSlopeLand;
        }
        else
        {
            steepSlopeLand.GetComponent<land>().SetSelectedLandVisabillity(false);
            Debug.Log("steepSlopeLand button is  active");

        }
    }


    /// ////////////////////////////////////////////////////////////////////////
     
    /**
     * handles the thickness of the soil. called by radio button clicked
     */
    public void HealthyTopsoilSelected()
    {
        healthyTopsoilSelectedFlag = !healthyTopsoilSelectedFlag;
        //find child game object with soil tag
        Debug.Log("currentSelectedObject is " + currentSelectedObject.name);
 
            //get the script and call function and pass true
        ChangeAllSilProfileThickness(healthyTopsoilSelectedFlag);       

    }

    /**
     * change the soil profile thickness. true is thick, false is thin
     */
    private void ChangeAllSilProfileThickness(bool isHealthy)
    {
        soilProfileFlat.GetComponent<SoilProfileGM>().SetTopsoilToHealthy(isHealthy);
        soilProfileSlope.GetComponent<SoilProfileGM>().SetTopsoilToHealthy(isHealthy);
        soilProfileSteepSlope.GetComponent<SoilProfileGM>().SetTopsoilToHealthy(isHealthy);
    }

    /**
     * called when the radio button is clicked. 
     * calls function to
     *  toggle visability of trees
     *  set color of profile
     *  set the color of the land
     * 
     */
    public void CoveredSelected()
    {
        isCoveredFlag = !isCoveredFlag;
        soilProfile = currentSelectedObject.transform.Find(childPathName).gameObject; //get the soil profile color and then use it to set the rest of the soils and lands
        SetColorOfProfile(isCoveredFlag); //set the color of the profile
        currentSoilProfileColor = soilProfile.GetComponent<SoilProfileGM>().GetHealthOfSoilCubeColor(); //get the soil profile color to change the land color
        SetVisabilityOfTreesForAllLands(isCoveredFlag); //set the visability of trees
        SetColorOfSoilForAllLands(currentSoilProfileColor); //changes the land color

    }

    /**
     * set the color of the soil profile
     */
    void SetColorOfProfile(bool isHealthy)
    {

        soilProfileFlat.GetComponent<SoilProfileGM>().SetTopsoilColorToHealthy(isHealthy); //changes the soil profile color
        soilProfileSlope.GetComponent<SoilProfileGM>().SetTopsoilColorToHealthy(isHealthy); //changes the soil profile color
        soilProfileSteepSlope.GetComponent<SoilProfileGM>().SetTopsoilColorToHealthy(isHealthy); //changes the soil profile color

    }

    /**
     * set the color of the land
     */
    void SetColorOfSoilForAllLands(Material color)
    {
        flatLand.GetComponent<land>().ChangeLandColor(color);
        slopeLand.GetComponent<land>().ChangeLandColor(color);
        steepSlopeLand.GetComponent<land>().ChangeLandColor(color);

    }

    /**
     * toggle the visability of the trees on the land
     */
    void SetVisabilityOfTreesForAllLands(bool visability)
    {
        flatLand.GetComponent<land>().treesForCover.SetActive(visability);
        slopeLand.GetComponent<land>().treesForCover.SetActive(visability);
        steepSlopeLand.GetComponent<land>().treesForCover.SetActive(visability);
    }
}
