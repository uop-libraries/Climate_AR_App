using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoneWithBrown : MonoBehaviour
{
    public GameObject topsoil;

    void DoneWithErosion()
    {
        topsoil.GetComponent<SoilCube>().DoneWithBrownErosion();
        Debug.Log("DoneWithBrown DoneWithErosion  script on the cube");
    }


}
