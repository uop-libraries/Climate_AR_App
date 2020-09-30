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
    // Start is called before the first frame update
    void Start()
    {
        healthyTopsoilSelectedFlag = true;
        isCoveredFlag = true;
        currentSelectedObject = flatLand;
        childPathName = "soil profile";
       
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

    public void HealthyTopsoilSelected()
    {
        healthyTopsoilSelectedFlag = !healthyTopsoilSelectedFlag;
        //find child game object with soil tag
        Debug.Log("currentSelectedObject is " + currentSelectedObject.name);
        soilProfile = currentSelectedObject.transform.Find(childPathName).gameObject;
        if (soilProfile == null)
        {
            Debug.LogError("unable to find child " + childPathName);
        }

        if (healthyTopsoilSelectedFlag) // healthy soil 
        {
            //get the script and call function and pass true
            soilProfile.GetComponent<SoilProfileGM>().SetTopsoilToHealthy(true);
        }
        else
        {
            soilProfile.GetComponent<SoilProfileGM>().SetTopsoilToHealthy(false);

        }

    }



    public void CoveredSelected()
    {
        isCoveredFlag = !isCoveredFlag;
        soilProfile = currentSelectedObject.transform.Find(childPathName).gameObject; //get the soil profile color and then use it to set the rest of the soils and lands
        SetColorOfProfile(isCoveredFlag); //set the color of the profile
        currentSoilProfileColor = soilProfile.GetComponent<SoilProfileGM>().GetHealthOfSoilCubeColor(); //get the soil profile color to change the land color
        SetVisabilityOfTreesForAllLands(isCoveredFlag); //set the visability of trees
        SetColorOfSoilForAllLands(currentSoilProfileColor); //changes the land color

    }

    void SetColorOfProfile(bool isHealthy)
    {
        GameObject soilProfileFlat = flatLand.transform.Find(childPathName).gameObject;
        GameObject soilProfileSlope = slopeLand.transform.Find(childPathName).gameObject;
        GameObject soilProfileSteepSlope = steepSlopeLand.transform.Find(childPathName).gameObject;
        soilProfileFlat.GetComponent<SoilProfileGM>().SetTopsoilColorToHealthy(isHealthy); //changes the soil profile color
        soilProfileSlope.GetComponent<SoilProfileGM>().SetTopsoilColorToHealthy(isHealthy); //changes the soil profile color
        soilProfileSteepSlope.GetComponent<SoilProfileGM>().SetTopsoilColorToHealthy(isHealthy); //changes the soil profile color

    }

    void SetColorOfSoilForAllLands(Material color)
    {
        flatLand.GetComponent<land>().ChangeLandColor(color);
        slopeLand.GetComponent<land>().ChangeLandColor(color);
        steepSlopeLand.GetComponent<land>().ChangeLandColor(color);

    }

    void SetVisabilityOfTreesForAllLands(bool visability)
    {
        flatLand.GetComponent<land>().treesForCover.SetActive(visability);
        slopeLand.GetComponent<land>().treesForCover.SetActive(visability);
        steepSlopeLand.GetComponent<land>().treesForCover.SetActive(visability);
    }
}
