using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGM : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject welcomePopup;
    public GameObject bubbles;
    public GameObject POIs;
    public GameObject sounds;
    void Start()
    {
        welcomePopup.SetActive(true);
        bubbles.SetActive(false);
        POIs.SetActive(false);
        sounds.SetActive(false);

    }

    public void CloseWelcomePopUp()
    {
        welcomePopup.SetActive(false);
        POIs.SetActive(true);

    }

    public void StartSounds()
    {
        sounds.SetActive(true);
    }
}
