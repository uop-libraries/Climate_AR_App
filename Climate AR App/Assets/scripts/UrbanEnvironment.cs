using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrbanEnvironment : MonoBehaviour
{
    public GameObject cityWater;
    public GameObject cityGroundWater;
    public GameObject leveeGroundWater;
    public GameObject clouds;
    public GameObject rainStorm;
    public GameObject rainSound;

    public float riverRaiseSpeed;
    public float riverExpanseAmount;
    public float cityRaiseSpeed;
    public float LeveeRaiseSpeed;

    private bool stormHappening;
    private float expandSize = .01f;
    private float sizeLimit = 2.4f;
    // Start is called before the first frame update
    void Start()
    {
        clouds.SetActive(false);
        rainStorm.SetActive(false);
        //rainSound.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentScale = clouds.transform.localScale;
        if (stormHappening && clouds.transform.localScale.z < sizeLimit) // add/grow the clouds
        {
            clouds.transform.localScale = new Vector3(currentScale.x + expandSize, currentScale.y + expandSize, currentScale.z + expandSize);
        }
        else if (!stormHappening && clouds.transform.localScale.z > 0f) // remove/shrink the clouds
        {
            clouds.transform.localScale = new Vector3(currentScale.x - expandSize, currentScale.y - expandSize, currentScale.z - expandSize);

        }
    }

    public void StartStorm(bool isRaising)
    {
        Debug.Log("start storm button clicked ");
        clouds.SetActive(true);
        stormHappening = true;
        rainStorm.SetActive(true);
        rainSound.GetComponent<EnviroAudioSource>().StartRainSound();
        rainSound.GetComponent<EnviroAudioSource>().playOnStart = true;
        Vector3 currentPosition = cityWater.transform.position;
        //Vector3 currentScale = cityWater.transform.localScale;
        if (isRaising)
        {
            cityWater.transform.position = new Vector3(currentPosition.x, currentPosition.y+riverRaiseSpeed, currentPosition.z);
            //cityWater.transform.localScale = new Vector3(currentScale.x + riverExpanseAmount, currentScale.y, currentScale.z);

            //  transform.position = new Vector3(transform.position.x, 0, transform.position.z);

        }
    }

    public void EndStorm()
    {
        Debug.Log("end storm button clicked");
        rainSound.GetComponent<EnviroAudioSource>().FadeOut();
       rainStorm.SetActive(false);
        //rainSound.SetActive(false);
        stormHappening = false;

    }
}
