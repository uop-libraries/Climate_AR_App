using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infiltration : MonoBehaviour
{
    public GameObject RainInfo;
    public float infiltrationAmountOverTime; //how much the ground can soak up over a certain time. asphalt is going to be really low since it cant soak up like anything....  VS grass land soaks up more
    public float waterStorageAmount; //the total water storage amount before the soil cannont hold anymore water
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //add code here to check if the rainfall amount causes surface water runoff
    }
}
