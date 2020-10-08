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
    [Tooltip("for poor managed land. 0.3f for flat. 0.9f sloped. 1.2f steep sloped. for good management land. 0.3f for flat. 0.6f for sloped. 0.9f for steep sloped")]
    public float startingErosionAmount; //the erosion amount to start with, might be subtracted from depending on user RUSLE choices
    public Material goodSoilColor;
    public Material badSoilColor;
    public GameObject grass;
    public GameObject MySoilGM;
   
    //public Animator animGreen;
    bool doneWithGreenErosion = false;
    bool doneWithBrownErosion = false;
    private GameObject Storm;
    // Start is called before the first frame update
    void Start()
    {
        //startingErosionAmount = .9f; //default
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
        Debug.Log(" the erosion is starting on object " + this.name);
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

    /**
     * when the animation on the brown soil is done then this function is called to signal that the erosion is done
     */
    public void DoneWithBrownErosion()
    {
  
        Storm = GameObject.FindWithTag("storm");
        if (Storm == null)
        {
            Debug.LogError("Error need to have object with tag storm");
        }
        else
        {

            if (this.isActiveAndEnabled) //if the soil profile is visable and done with erosion, then its done
            {
                doneWithBrownErosion = true;
                MySoilGM.GetComponent<SoilProfileGM>().SetErosionOnCubeDone(doneWithBrownErosion);

            }

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

    public bool GetIsDoneWithBrownErosion()
    {
        return doneWithBrownErosion;
    }

    /**
     * resets the green and brown soils
     */
    public void ResetAllSoils()
    {
        brownCube.GetComponent<Animator>().SetBool("isErosionBrownTime", false);// start the erosion animation
        this.GetComponent<Animator>().SetBool("isErosionTime", false);// start the erosion animation
        this.GetComponent<Animator>().SetFloat("erosionSpeed", 4f); //speedy reset
        brownCube.GetComponent<Animator>().SetFloat("erosionSpeed", 4f); //speedy reset
        grass.SetActive(true);
        this.GetComponent<Renderer>().enabled = true; //show the green cube
        doneWithBrownErosion = false;
        MySoilGM.GetComponent<SoilProfileGM>().SetErosionOnCubeDone(doneWithBrownErosion);


    }
}
