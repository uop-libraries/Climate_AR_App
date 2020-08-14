using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleManager : MonoBehaviour
{
    public GameObject visual;
    // Start is called before the first frame update
    void Start()
    {
        visual.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            visual.SetActive(true);
            this.GetComponent<AudioSource>().Play();
            Debug.LogError("bubble trigger enter");
        }

    }

    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("MainCamera"))
        {
            visual.SetActive(false);
            Debug.LogError("bubble trigger exit");

        }

    }
}
