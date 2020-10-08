using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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



    public void SceneSelection(string sceneName)
    {
        loading.SetActive(true);
        SceneManager.LoadScene(sceneName);
    }

    public void SetCreditTextActive(bool isActive)
    {
        creditText.SetActive(isActive);
    }
    public void CloseApp()
    {
        Application.Quit();
    }
}
