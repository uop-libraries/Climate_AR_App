using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * this script exist for the anim on the brown soil cube to call to to signal being done with erosion
 */
public class DoneWithBrown : MonoBehaviour
{
    public GameObject topsoil;

    void DoneWithErosion()
    {
        topsoil.GetComponent<SoilCube>().DoneWithBrownErosion();
        Debug.Log("DoneWithBrown DoneWithErosion  script on the cube");
    }



}
