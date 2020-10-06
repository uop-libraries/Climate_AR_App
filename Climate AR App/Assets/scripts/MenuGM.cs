using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGM : MonoBehaviour
{
    public GameObject loading;
    // Start is called before the first frame update
    void Start()
    {
        loading.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SceneSelection(string sceneName)
    {
        loading.SetActive(true);
        SceneManager.LoadScene(sceneName);
    }

    public void CloseApp()
    {
        Application.Quit();
    }
}
