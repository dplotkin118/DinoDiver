// ﻿using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
//
// public class sharkCam : MonoBehaviour
// {
//
//     public GameObject normalCam;
//     public GameObject sharkCamwee;
//     public GameObject trigger;
//     // Start is called before the first frame update
//
//     public void OnTriggerEnter2D(Collider2D other)
//     {
//       if(other.gameObject.tag == "Player")
//       {
//         normalCam.SetActive(false);
//         sharkCamwee.SetActive(true);
//         StartCoroutine("SharkCamSwitch");
//         normalCam.SetActive(true);
//         sharkCamwee.SetActive(false);
//         Destroy(trigger);
//       }
//     }
//
//     IEnumerator SharkCamSwitch()
//     {
//       yield return new WaitForSeconds(2f);
//
//     }
// }
