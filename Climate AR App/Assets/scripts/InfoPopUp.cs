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
    public bool showSpecialOnce;
    public GameObject planeFinder;
    public float ColliderRadius;
    public bool lastPOI; //on the inspector, set true if it is the last POI and you want to bring user to main menu
    public GameObject arrow;
    private bool showed;//used to handle the logic so the special POI is only shown once (unless restarted). 
    //this prevents the user from walking into th detection zone and retriggering the pop up which can get annoying.
    // Start is called before the first frame update

    private void Start()
    {
        showed = false;

    }
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
            else if (showSpecialOnce) //special event time, show once
            {
                if (!showed)
                {
                    specialEvent.SetActive(true);
                    planeFinder.GetComponent<AnchorInputListenerBehaviour>().enabled = true;
                    showed = true;
                }

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


    /**
     * used to reset the POI, make the show param false to reset
     */
    public void SetShowed(bool show)
    {
        Debug.Log("SetShowed " + show);
        showed = show;
    }

    public void SetArrowActive(bool isActive)
    {
        arrow.SetActive(isActive);
    }

}
