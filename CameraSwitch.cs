using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraSwitch : MonoBehaviour
{

    public Camera NormalCam;
    public Camera BossCam;
   

    public void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject hitObj = collider.gameObject;

        if (hitObj.tag == "Player")
        {
            NormalCam.enabled = false;
            BossCam.enabled = true;
        }
    }
}
