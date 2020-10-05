using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioGM : MonoBehaviour
{

    public GameObject[] sounds;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            sounds[i].SetActive(false);

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**start a specific sound in the level
    * 
    */
    public void StartSingleSounds(int i)
    {
        sounds[i].SetActive(true);
    }

    /**
     * set active all of the sounds in the array
     */
    public void ToggleAllSounds(bool setOn)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            sounds[i].SetActive(setOn);

        }
    }
}
