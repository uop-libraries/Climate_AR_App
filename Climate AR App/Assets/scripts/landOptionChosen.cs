using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class landOptionChosen : MonoBehaviour
{
    public GameObject badSideCanvas;
    public GameObject badSideGM;

    public GameObject goodSideCanvas;
    public GameObject goodSideGM;

    public GameObject infoPopUpCanvas;
    public Text InfoPopupText;

    // Start is called before the first frame update
    void Start()
    {
        infoPopUpCanvas.SetActive(false);
    }

    /**
     * called with the done with bad option side done
     */
    public void DoneWithBadSide()
    {
        Debug.Log("done with bad side");
        badSideCanvas.SetActive(false);
        InfoPopupText.text = badSideGM.GetComponent<landGM>().DoneWithSelection(); //set the text
        infoPopUpCanvas.SetActive(true); //show the text

    }

    /**
    * called with the done with good option side done
    */
    public void DoneWithGoodSide()
    {
        Debug.Log("done with good side");
        goodSideCanvas.SetActive(false);
    }

    /**
     * hide the info on the page
     */
    public void HideInfo()
    {
        infoPopUpCanvas.SetActive(false);
    }
}
