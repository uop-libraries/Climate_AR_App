using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]

/**
 * handles the logic for each cube. stack the cube to make your soil profile. 
 * can change the color between good and bad 
 * if top cube (top soil) shrink by certian amount
 */
public class SoilCube : MonoBehaviour
{
    public bool isTopCube;
    public float erosionAmount; //the amount that the top will be shrunk by 
    public Material goodSoilColor;
    public Material badSoilColor;
    // Start is called before the first frame update
    void Start()
    {
        StartErosion();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
     * handles the color of the soil based on bool parameter. 
     * true = healthy green soil 
     * false = bad unhealthy yellowish soil
     */
    public void IsSoilGood(bool isTheSoilGood)
    {
        if (isTheSoilGood)
        {
            gameObject.GetComponent<Renderer>().material = goodSoilColor;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material = badSoilColor;
        }

    }

    /**
     * handles the erosion of the top cube (top soil). this function is called by a public function to start the erosion process
     */
    void Eroode()
    {
        //get animation paramter for speed
        //animations[i].GetComponent<Animator>().SetBool("StartRiverIncrease", true); //start the animation, the string value is a parameter from the animator window
        GetComponent<Animator>().SetBool("isErosionTime", true);// start the erosion animation
        GetComponent<Animator>().SetFloat("erosionSpeed", erosionAmount); // adjust the speed of animation. this ammount is a multiplied amount


    }

    public void StartErosion()
    {
        Eroode();
    }
}
