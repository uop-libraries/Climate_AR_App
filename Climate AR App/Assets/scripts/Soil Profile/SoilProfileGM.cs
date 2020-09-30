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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



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
            //Debug.Log("healthySoilCubeScriptHolder in soil color GM set the topsoil to good");
            healthySoilCubeScriptHolder.GetComponent<SoilCube>().IsSoilGood(isHealthy);
            unHealthySoilCubeScriptHolder.GetComponent<SoilCube>().IsSoilGood(isHealthy);
            //return healthySoilCubeScriptHolder.GetComponent<SoilCube>().GetSoilColor();
        }
        else  // hide the soil
        {
            //Debug.Log("healthySoilCubeScriptHolder in soil color GM set the topsoil to bad");
            healthySoilCubeScriptHolder.GetComponent<SoilCube>().IsSoilGood(isHealthy);
            unHealthySoilCubeScriptHolder.GetComponent<SoilCube>().IsSoilGood(isHealthy);
            //return healthySoilCubeScriptHolder.GetComponent<SoilCube>().GetSoilColor();
        }
    }

    public Material GetHealthOfSoilCubeColor()
    {
        return healthySoilCubeScriptHolder.GetComponent<SoilCube>().GetSoilColor();
    }
}
