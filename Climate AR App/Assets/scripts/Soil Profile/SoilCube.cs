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
    public GameObject brownCube;
    [Tooltip("0.3f for flat. 0.6f sloped. 0.9f steep sloped")]
    public float startingErosionAmount; //the erosion amount to start with, might be subtracted from depending on user RUSLE choices
    public Material goodSoilColor;
    public Material badSoilColor;
    public GameObject grass;
   
    //public Animator animGreen;
    bool doneWithGreenErosion = false;
    private GameObject Storm;
    // Start is called before the first frame update
    void Start()
    {

    }

    /**
     * handles the animation start for the brown cube.
     */
    void ErodeBrownCube()
    {
        brownCube.GetComponent<Animator>().SetBool("isErosionBrownTime", true);// start the erosion animation
        brownCube.GetComponent<Animator>().SetFloat("erosionSpeed", startingErosionAmount); // adjust the speed of animation. this ammount is a multiplied amount
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
            //Debug.Log("in soil cube, good soil color is now " + goodSoilColor);
        }
        else
        {
            gameObject.GetComponent<Renderer>().material = badSoilColor;
            //Debug.Log("in soil cube, bad soil color is now " + badSoilColor);
        }

    }

    /**
     * handles the erosion of the top cube (top soil). this function is called by a public function to start the erosion process
     */
    void Eroode()
    {
        //get animation paramter for speed
        //animations[i].GetComponent<Animator>().SetBool("StartRiverIncrease", true); //start the animation, the string value is a parameter from the animator window
        
        this.GetComponent<Animator>().SetFloat("erosionSpeed", startingErosionAmount); // adjust the speed of animation. this ammount is a multiplied amount

        this.GetComponent<Animator>().SetBool("isErosionTime", true);// start the erosion animation
        


    }

    /**
     * called by anim event
     */
    void DoneWithGreenErosion()
    {
        Debug.Log("DONE WITH GREEN");
        ErodeBrownCube(); 
        this.GetComponent<Renderer>().enabled = false; //hide the green cube
    }


    public void DoneWithBrownErosion()
    {
        //stop rain
        Debug.Log("jjjjjjjjjjjjjjjj Brown erosion is done");
        //Storm.GetComponent<agricultureStorm>().EndStorm();
        //find the storm object dynamically
        Storm = GameObject.FindWithTag("storm");
        if (Storm == null)
        {
            Debug.LogError("Error need to have object with tag storm");
        }
        else
        {
            Storm.GetComponent<agricultureStorm>().EndStorm();
        }

    }

    /**
     * called by anim event
     */
    void HideGrass()
    {
        grass.SetActive(false);
    }
    /**
     * start the erosion of the soil profile
     */
    public void StartErosion()
    {
        Eroode();
    }

    /**
     * get the current color of the soil profile
     */
    public Material GetSoilColor()
    {
        return gameObject.GetComponent<Renderer>().material;
    }

    public void SetErosionAmount(float amount)
    {
        startingErosionAmount = amount;
    }

    public float GetErosionAmount()
    {
        return startingErosionAmount;
    }
}
