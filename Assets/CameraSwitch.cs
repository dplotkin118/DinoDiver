
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraSwitch : MonoBehaviour
{

  public GameObject NormalCam;
  public GameObject BossCam;
  public GameObject door;
  public GameObject trigger;
  public GameObject boss;

  public void OnTriggerEnter2D(Collider2D collider)
  {
      GameObject hitObj = collider.gameObject;

      if (hitObj.tag == "Player")
      {
          if(boss != null)
          {
            boss.SetActive(true);
            BossDefeat.spawnWeenies = true;
          }
          NormalCam.SetActive(false);
          BossCam.SetActive(true);
          door.SetActive(true);
          trigger.SetActive(false);
      }
  }
}
