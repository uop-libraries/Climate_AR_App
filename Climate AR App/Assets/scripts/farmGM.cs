using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class farmGM : MonoBehaviour
{
    public GameObject goodFarm;
    public GameObject badFarm;
    public GameObject goodFarmOptions;
    public GameObject badFarmOptions;
    // Start is called before the first frame update
    void Start()
    {
        SetActiveStartingFarmssAndOptionsFarms(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetActiveStartingFarmssAndOptionsFarms(bool flag)
    {
        goodFarm.SetActive(flag);
        badFarm.SetActive(flag);
        goodFarmOptions.SetActive(!flag);
        badFarmOptions.SetActive(!flag);
    }
}
