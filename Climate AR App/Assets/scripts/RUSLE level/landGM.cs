using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class landGM : MonoBehaviour
{
    public GameObject flatLand;
    public GameObject slopeLand;
    public GameObject steepSlopeLand;
    public GameObject treesForCover;
    public Material goodSoilColor;
    public Material badSoilColor;

    private bool healthyTopsoilSelectedFlag; //make sure the radio toggle button is checked in scene mode
    private GameObject currentSelectedObject;
    private GameObject soilProfile;
    private string childPathName;
    // Start is called before the first frame update
    void Start()
    {
        healthyTopsoilSelectedFlag = true;
        currentSelectedObject = flatLand;
        childPathName = "soil profile";
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FlatSelected()
    {
        flatLand.GetComponent<land>().ToggleIsSelected();
        currentSelectedObject = flatLand;
    }

    public void SlopeSelected()
    {
        slopeLand.GetComponent<land>().ToggleIsSelected();
        currentSelectedObject = slopeLand;
    }

    public void SteepSlopeSelected()
    {
        steepSlopeLand.GetComponent<land>().ToggleIsSelected();
        currentSelectedObject = steepSlopeLand;
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

    }
}
