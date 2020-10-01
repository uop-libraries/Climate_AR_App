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
    Animator animGreen;
    // Start is called before the first frame update
    void Start()
    {
        animGreen = GetComponent<Animator>();
        //StartErosion();
    }

    // Update is called once per frame
    void Update()
    {
        //if (animGreen.GetBool("isErosionTime") && gameObject.GetComponent<Renderer>().enabled && animGreen.GetCurrentAnimatorStateInfo(0).normalizedTime > 1) //erosion animation is done playing. If normalizedTime is 0 to 1 = playing, if greater than 1 = finished
        if (animGreen.GetCurrentAnimatorStateInfo(0).normalizedTime > 1) //erosion animation is done playing. If normalizedTime is 0 to 1 = playing, if greater than 1 = finished
        {
            //this.GetComponent<Renderer>().enabled = false; //hide the green
            Debug.Log("done with green anim");
            //check if green is done animating
            // if true
            // call erodeBrownCube          
            float temp = animGreen.GetCurrentAnimatorStateInfo(0).normalizedTime;
            Debug.Log(" animGreen.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 " + temp);

        }
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
        
        animGreen.SetFloat("erosionSpeed", startingErosionAmount); // adjust the speed of animation. this ammount is a multiplied amount

        animGreen.SetBool("isErosionTime", true);// start the erosion animation
        


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
