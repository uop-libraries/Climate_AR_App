using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * handles the cubes for a single soil porfile. show and hide profile here
 * 
 */
public class SoilProfileGM : MonoBehaviour
{
    public GameObject healthyTopsoil;
    public GameObject unhealthyTopSoil;
    public GameObject healthySoilCubeScriptHolder;
    public GameObject unHealthySoilCubeScriptHolder;

    /**
     * set the top soils health. true show the thick topsoil, false is thing topsoil
     */
    public void SetTopsoilToHealthy(bool flag)
    {
        if (flag) //show healthy soil
        {
            healthyTopsoil.SetActive(flag);
            unhealthyTopSoil.SetActive(!flag);
        }
        else // hide the soil
        {
            unhealthyTopSoil.SetActive(!flag);
            healthyTopsoil.SetActive(flag);
        }
    }

    /**
     * set the top soils health. true show the color be green , false is color being yellow
     */
    public void SetTopsoilColorToHealthy(bool isHealthy)
    {
        //Debug.Log("is healthySoilCubeScriptHolder active soil " + healthySoilCubeScriptHolder.activeInHierarchy);
        if (isHealthy) //show healthy soil
        {
            healthySoilCubeScriptHolder.GetComponent<SoilCube>().IsSoilGood(isHealthy);
            unHealthySoilCubeScriptHolder.GetComponent<SoilCube>().IsSoilGood(isHealthy);
        }
        else  // hide the soil
        {
            healthySoilCubeScriptHolder.GetComponent<SoilCube>().IsSoilGood(isHealthy);
            unHealthySoilCubeScriptHolder.GetComponent<SoilCube>().IsSoilGood(isHealthy);
        }
    }

    /**
     * get the color of the soil from the healthy cube
     */
    public Material GetHealthOfSoilCubeColor()
    {
        return healthySoilCubeScriptHolder.GetComponent<SoilCube>().GetSoilColor();
    }

    /**
     * sets the amount of erosion on both healthy and un healthy profiles
     */
    public void SetErosionAmountOnProfiles(float passedErosionAmount)
    {
        healthySoilCubeScriptHolder.GetComponent<SoilCube>().SetErosionAmount(passedErosionAmount);
        unHealthySoilCubeScriptHolder.GetComponent<SoilCube>().SetErosionAmount(passedErosionAmount);

    }

    /**
     * getter for the erosion of the healthy soil profile
     */
    public float GetErosionOfHealthyProfile()
    {
        return healthySoilCubeScriptHolder.GetComponent<SoilCube>().GetErosionAmount();
    }

    /**
    * getter for the erosion of the unhealthy soil profile
    */
    public float GetErosionOfUnHealthyProfile()
    {
        return unHealthySoilCubeScriptHolder.GetComponent<SoilCube>().GetErosionAmount();
    }

    /**
     * start the erosion on both profiles
     */
    public void StartErosionsOnProfiles()
    {
        Debug.Log("start the erosion in soil profile GM on object " + this.name);
        healthySoilCubeScriptHolder.GetComponent<SoilCube>().StartErosion();
        unHealthySoilCubeScriptHolder.GetComponent<SoilCube>().StartErosion();
    }
}
