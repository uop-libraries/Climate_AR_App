using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Audio manager
 * mainly used in the urban level
 * requries an array of gameoobjects with the assumption those objects have an audio source component
 * can toggle active on all objects in array or at a specific index
 */
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
