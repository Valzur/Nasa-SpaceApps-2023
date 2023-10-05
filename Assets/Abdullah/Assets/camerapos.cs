using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerapos : MonoBehaviour
{
    public GameObject thirdP, firstP;
    public static bool IsThirdPerson = true;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            firstP.SetActive(true);
            thirdP.SetActive(false);
            IsThirdPerson = false;
        }
        if(Input.GetKeyDown(KeyCode.T))
        {
            IsThirdPerson = true;
            thirdP.SetActive(true);
            firstP.SetActive(false);
        }
    }
}
