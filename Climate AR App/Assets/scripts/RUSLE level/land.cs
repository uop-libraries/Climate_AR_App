using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class land : MonoBehaviour
{

    public bool isSelected;
    public GameObject treesForCover;
    public GameObject theLand;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ToggleIsSelectedLand()
    {
        isSelected = !isSelected;
        this.gameObject.SetActive(isSelected);
        Debug.Log("isSelected " + isSelected);
    }
    
    public void ChangeLandColor(Material color)
    {
        Debug.Log("change land color " + color);
        theLand.GetComponent<Renderer>().material = color;
    }
}

