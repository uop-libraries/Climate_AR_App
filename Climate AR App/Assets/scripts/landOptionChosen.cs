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
    public GameObject contentText;

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
        ResetTextPosition();
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
        ResetTextPosition();
        goodSideCanvas.SetActive(false);
        InfoPopupText.text = goodSideGM.GetComponent<landGM>().DoneWithSelection(); //set the text
        infoPopUpCanvas.SetActive(true); //show the text
    }

    /**
     * hide the info on the page
     */
    public void HideInfo()
    {
        infoPopUpCanvas.SetActive(false);
    }

    /**
     * reset the text position to the top for when the next RUSTLE options are chosen. 
     */
    void ResetTextPosition()
    {
        contentText.transform.localPosition = new Vector3(contentText.transform.localPosition.x, 0f, contentText.transform.localPosition.z);

    }
}
