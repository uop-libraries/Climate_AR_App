using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class land : MonoBehaviour
{
    private bool isHealthyTopsoil;
    private bool isCovered;
    private bool isSelected;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetIsCovered(bool value)
    {
        isCovered = value;
    }
    
    public void SetIsHealthyTopsoil(bool value)
    {
        isHealthyTopsoil = value;
    }

    public void ToggleIsSelected()
    {
        isSelected = !isSelected;
    }
    
}

