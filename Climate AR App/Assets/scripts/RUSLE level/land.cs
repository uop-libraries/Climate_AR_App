using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class land : MonoBehaviour
{
    public bool isHealthyTopsoil;
    public bool isCovered;
    public bool isSelected;
    public GameObject treesForCover;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetIsCovered()
    {
        isCovered = !isCovered;
    }
    
    public void SetIsHealthyTopsoil()
    {
        isHealthyTopsoil = !isHealthyTopsoil;
    }

    public void ToggleIsSelectedLand()
    {
        isSelected = !isSelected;
        this.gameObject.SetActive(isSelected);
        Debug.Log("isSelected " + isSelected);
    }
    
}

