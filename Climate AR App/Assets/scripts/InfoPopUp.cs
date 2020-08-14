using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPopUp : MonoBehaviour
{
    public GameObject popUp; //the pop up for the user to read
    public Text popUptext;
    public GameObject PopUPGM;
    public bool specialEventPOI;
    public string textForButton; //what the button will say "continue" "close" "start" etc
    public GameObject specialEvent;
    // Start is called before the first frame update
    void Start()
    {
        //HideSpecialEvent();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if (!specialEventPOI)
            {
                popUp.SetActive(true);
                popUptext.text = GetComponent<Text>().text;
                PopUPGM.GetComponent<PopUpHandler>().ResetTextPosition();
            }
            else //special event time
            {
                specialEvent.SetActive(true);
            }
            
        }
    }

    public void HideSpecialEvent()
    {
        if (specialEvent != null)
        {
            specialEvent.SetActive(false);

        }
    }


}
