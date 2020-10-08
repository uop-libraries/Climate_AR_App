using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** 
 * manages the collider and detection of the AR camera so it is only trigger by the user holding the phone
 * used on pie prefab that is instiated at runtime by the graph and chart asset
 */
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
            //Debug.LogError("bubble trigger enter");
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
