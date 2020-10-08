using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * holds the reference to the good and bad land GM and the canvases along with them.
 * once the good or bad land is chosen, then this script will pop up the info canvas to learn 
 * also handles the reselect canvas and arrow
 */
public class landOptionChosen : MonoBehaviour
{
    public GameObject badSideCanvas;
    public GameObject badSideGM;

    public GameObject goodSideCanvas;
    public GameObject goodSideGM;

    public GameObject infoPopUpCanvas;
    public Text InfoPopupText;
    public GameObject contentText;

    public GameObject reselectCanvas;
    public GameObject reselectPOIArrow;

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
        //Debug.Log("done with bad side");
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
        //Debug.Log("done with good side");
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

    /**
     * reset the soils, called by button
     */
    public void ResetSoils()
    {
        badSideGM.GetComponent<landGM>().ResetSoilsFromLandGM();
        goodSideGM.GetComponent<landGM>().ResetSoilsFromLandGM();

    }

    /**
     * set the view of the canvas to reselect or be done of RUSLE
     */
    public void SetReselectCanvas(bool show)
    {
        reselectCanvas.SetActive(show);
    }

    /**
     * handles the visability of the arrow showen after the storm is completed
     */
    public void SetActiveReselectPOIArrow(bool isActive)
    {
        reselectPOIArrow.SetActive(isActive);
    }
}
