using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * handles the cubes for a single soil porfile. show and hide profile here
 * 
 */
public class SoilProfileGM : MonoBehaviour
{
    public GameObject[] cubes;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
     * hide or show the porfile based off of the passed in bool value. true = show, false = hide
     */
    public void ShowAll(bool flag)
    {
        for (int i = 0; i < cubes.Length; i++)
        {
            cubes[i].SetActive(flag);
        }
    }
}
