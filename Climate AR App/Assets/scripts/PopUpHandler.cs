using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/**
 * Handles going through the POI's in the scene. Also handles events
 */
public class PopUpHandler : MonoBehaviour
{
    public GameObject POIsParent;
    public GameObject popUp; //the pop up for the user to read
    public Text outOfNum;
    public GameObject contentText;
    public Scrollbar scroll;
    public Button CustomButton; //drag-n-drop the button in the CustomButton field   
    public GameObject ARCamera;
    int currentPOIIndex = 0; //the order of POI's are determined by their position in the hirearchy
    List<GameObject> allPOIs = new List<GameObject>();
    float saveTextPosition;
    // Start is called before the first frame update
    void Start()
    {
        scroll.value = 1f;
        popUp.SetActive(false);
        //get all of the POI's
        foreach (Transform t in POIsParent.GetComponentInChildren<Transform>()) //not working
        {
            allPOIs.Add(t.gameObject);
        }
        HideAllPOIs();
        ShowPOIAtIndex(currentPOIIndex); //start with the first POI
        Debug.Log("the number of POIs is " + allPOIs.Count);
        outOfNum.text = currentPOIIndex.ToString() + " out of " + allPOIs.Count;
    }


    void Awake()
    {
        CustomButton.onClick.AddListener(CustomButton_onClick); //subscribe to the onClick event
    }

    /**
     * hide all of the POI's
     */
    public void HideAllPOIs()
    {
        for (int i = 0; i < allPOIs.Count; i++)
        {
            allPOIs[i].SetActive(false);
        }
    }
    
    public void ShowPOIAtIndex(int index)
    {
        if (index >= 0 && index < allPOIs.Count)
        {
            allPOIs[index].SetActive(true);
            CustomButton.GetComponentInChildren<Text>().text = allPOIs[index].GetComponentInChildren<InfoPopUp>().textForButton; //set the button text
        }
        else
        {
            Debug.LogError("index " + index + " is out of bounds");
        }
    }

    public void HidePOIAtIndex(int index)
    {
        if (index >= 0 && index < allPOIs.Count )
        {
            allPOIs[index].SetActive(false);
            popUp.SetActive(false);
        }
        else
        {
            Debug.LogError("index " + index + " is out of bounds");
        }
    }

    //Handle the onClick event
    void CustomButton_onClick()
    {
        //Debug.Log("test close button");
        PlayButtonSound();
        HidePOIAtIndex(currentPOIIndex); //hide the current viewed POI. 
        Debug.Log("Current POI index is " + currentPOIIndex);
        Debug.Log("POI object title is " + allPOIs[currentPOIIndex].name);
        if (allPOIs[currentPOIIndex].gameObject.transform.Find("collider And Text").GetComponent<InfoPopUp>().GetLastPOI())
        {
            //change scene here
            SceneManager.LoadScene("mainMenu");
        }
        currentPOIIndex++;
        ShowPOIAtIndex(currentPOIIndex); //show the next POI to go to       
        outOfNum.text = currentPOIIndex.ToString() + " out of " + allPOIs.Count;
    }


    /**
     * called by the button that is clicked to end the speical event and continue looking at the POI's
     */
    public void DoneWithSpecialEvent()
    {
        allPOIs[currentPOIIndex].GetComponentInChildren<InfoPopUp>().HideSpecialEvent(); //hide the special event and move to next POI
        CustomButton_onClick();
    }

    public void PlayButtonSound()
    {
        this.GetComponent<AudioSource>().Play();
    }

    /**
     * handles reseting the text position of the text
     */
    public void ResetTextPosition()
    {
        contentText.transform.localPosition = new Vector3(contentText.transform.localPosition.x, 0f, contentText.transform.localPosition.z);
    }

    /**
     * used to reset the poi for farm storm event
     */
    public void SetCurrentPOIIndex(int number)
    {
        Debug.Log("set the currentPOI to " + number);
        currentPOIIndex = number;
        ShowPOIAtIndex(currentPOIIndex);
    }

}
