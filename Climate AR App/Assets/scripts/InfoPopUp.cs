using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;
public class InfoPopUp : MonoBehaviour
{
    public GameObject popUp; //the pop up for the user to read
    public Text popUptext;
    public GameObject PopUPGM;
    public bool specialEventPOI;
    public string textForButton; //what the button will say "continue" "close" "start" etc
    public GameObject specialEvent;
    public GameObject planeFinder;
    public float ColliderRadius;
    public bool lastPOI; //on the inspector, set true if it is the last POI and you want to bring user to main menu
    // Start is called before the first frame update
    void Awake() //want the radius of the collider set before they are set active
    {
        //instead of adjusting the camera's collider lets try it with the POI
        CapsuleCollider TriggerCollider = this.GetComponent<CapsuleCollider>();
        TriggerCollider.radius = ColliderRadius;
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
                planeFinder.GetComponent<AnchorInputListenerBehaviour>().enabled = false;

            }
            else //special event time
            {
                specialEvent.SetActive(true);
                planeFinder.GetComponent<AnchorInputListenerBehaviour>().enabled = true;

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

    public bool GetLastPOI()
    {
        return lastPOI;
    }


}
