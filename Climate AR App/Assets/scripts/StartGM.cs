﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGM : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject welcomePopup;
    public GameObject bubbles;
    public GameObject POIs;
    void Start()
    {
        welcomePopup.SetActive(true);
        bubbles.SetActive(false);
        POIs.SetActive(false);

    }

    public void CloseWelcomePopUp()
    {
        welcomePopup.SetActive(false);
        POIs.SetActive(true);

    }
}
