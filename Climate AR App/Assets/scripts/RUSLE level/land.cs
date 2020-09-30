using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class land : MonoBehaviour
{

    public GameObject treesForCover;
    public GameObject theLand;
    public Toggle button;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetSelectedLandVisabillity(bool visability)
    {
        this.gameObject.SetActive(visability);
        Debug.Log("visability " + visability);
    }
    
    public void ChangeLandColor(Material color)
    {
        Debug.Log("change land color " + color);
        theLand.GetComponent<Renderer>().material = color;
    }

    public bool GetButtonIsOn()
    {
        return button.isOn;
    }
}

