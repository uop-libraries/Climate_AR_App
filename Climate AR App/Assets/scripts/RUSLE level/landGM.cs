using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class landGM : MonoBehaviour
{
    public GameObject flatLand;
    public GameObject slopeLand;
    public GameObject steepSlopeLand;
    public Material goodSoilColor;
    public Material badSoilColor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FlatSelected()
    {
        flatLand.GetComponent<land>().ToggleIsSelected();
    }

    public void SlopeSelected()
    {
        slopeLand.GetComponent<land>().ToggleIsSelected();
    }

    public void SteepSlopeSelected()
    {
        steepSlopeLand.GetComponent<land>().ToggleIsSelected();
    }
}
