using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * handles the switching between the starting farms with barns to the farms on RUSLE choices.
 */
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

    /**
     * swtich from the starting farms with barns, to the RUSLE farms
     */
    public void SetActiveStartingFarmssAndOptionsFarms(bool flag)
    {
        goodFarm.SetActive(flag);
        badFarm.SetActive(flag);
        goodFarmOptions.SetActive(!flag);
        badFarmOptions.SetActive(!flag);
    }
}
