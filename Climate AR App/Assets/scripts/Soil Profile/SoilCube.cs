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
    public bool greenTopCube;
    public GameObject brownCube;
    public float erosionAmount; //the amount that the top will be shrunk by 
    public Material goodSoilColor;
    public Material badSoilColor;
    public GameObject grass;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        StartErosion();
    }

    // Update is called once per frame
    void Update()
    {
        if (greenTopCube && anim.GetBool("isErosionTime") && gameObject.GetComponent<Renderer>().enabled && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1) //erosion animation is done playing. If normalizedTime is 0 to 1 = playing, if greater than 1 = finished
        {
            this.GetComponent<Renderer>().enabled = false; //hide the green
            if (grass != null)
            {
                grass.SetActive(false);
            }
            if (brownCube != null)
            {
                brownCube.GetComponent<Animator>().SetBool("isErosionBrownTime", true);// start the erosion animation
                brownCube.GetComponent<Animator>().SetFloat("erosionSpeed", erosionAmount); // adjust the speed of animation. this ammount is a multiplied amount

            }
        }
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
        
        anim.SetBool("isErosionTime", true);// start the erosion animation
        
        anim.SetFloat("erosionSpeed", erosionAmount); // adjust the speed of animation. this ammount is a multiplied amount


    }

    public void StartErosion()
    {
        Eroode();
    }


}
