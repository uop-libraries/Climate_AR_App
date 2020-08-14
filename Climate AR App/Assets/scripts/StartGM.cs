using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGM : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject welcomePopup;
    void Start()
    {
        welcomePopup.SetActive(true);
    }

    public void CloseWelcomePopUp()
    {
        welcomePopup.SetActive(false);

    }
}
