using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * GM for the menu
 * handles the switching between the canvas scenes
 */
public class MenuGM : MonoBehaviour
{
    public GameObject loading;
    public GameObject creditText;
    // Start is called before the first frame update
    void Start()
    {
        loading.SetActive(false);
        SetCreditTextActive(false);
    }



    /**
     * handles the scene selection. 
     * called by button
     */
    public void SceneSelection(string sceneName)
    {
        loading.SetActive(true);
        SceneManager.LoadScene(sceneName);
    }

    /**
     * set the credit window active or not based on parameter
     * called by button
     */
    public void SetCreditTextActive(bool isActive)
    {
        creditText.SetActive(isActive);
    }
    /**
     * close the app 
     * called by button
     */
    public void CloseApp()
    {
        Application.Quit();
    }
}
