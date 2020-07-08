﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrbanEnvironment : MonoBehaviour
{
    public GameObject cityWater;
    public GameObject cityGroundWater;
    public GameObject leveeGroundWater;

    public float riverRaiseSpeed;
    public float riverExpanseAmount;
    public float cityRaiseSpeed;
    public float LeveeRaiseSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FloodTime(bool isRaising)
    {
        Vector3 currentPosition = cityWater.transform.position;
        //Vector3 currentScale = cityWater.transform.localScale;
        if (isRaising)
        {
            cityWater.transform.position = new Vector3(currentPosition.x, currentPosition.y+riverRaiseSpeed, currentPosition.z);
            //cityWater.transform.localScale = new Vector3(currentScale.x + riverExpanseAmount, currentScale.y, currentScale.z);

            //  transform.position = new Vector3(transform.position.x, 0, transform.position.z);

        }
    }
}
