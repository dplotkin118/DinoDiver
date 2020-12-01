using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraSwitch : MonoBehaviour
{

    public GameObject NormalCam;
    public GameObject BossCam;
   

    public void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject hitObj = collider.gameObject;

        if (hitObj.tag == "Player")
        {
            NormalCam.SetActive(false);
            BossCam.SetActive(true);
        }
    }
}
