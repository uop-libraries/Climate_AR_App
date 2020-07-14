using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Ground
 * handles the characteristics of each ground area in the level.
 * not sure if this handles the river area too...that will need to be addressed
 * a ground objects should containt the water objects has childern objects. the parent of those childern is where this script is placed.
 * reference: http://www.fao.org/3/S8684E/s8684e0a.htm
 */
public class Ground : MonoBehaviour
{
    public float infiltrationAmountOverTime; //how much the ground can soak up over a certain time. asphalt is going to be really low since it cant soak up like anything....  VS grass land soaks up more
    public float waterStorageAmount; //the total water storage amount before the soil cannont hold anymore water. think if this has the MAX size. 
    public float delayWaterInfiltration; //used to simulate when the initial rainfall hits the ground and soaks up. a rich soil will have a low delay time. (initial infiltration )
    public float maxWaterLevel; //the limit of how high the water will go before flooding into the ocean etc

    float groundLevel; //the ground level of the ground area
    // Start is called before the first frame update
    void Start()
    {
        groundLevel = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetAdjustedDelayWaterInfiltration()
    {
        //Debug.Log(" GetAdjustedDelayWaterInfiltration = " + groundLevel + delayWaterInfiltration);
        return groundLevel + delayWaterInfiltration;
    }
}
