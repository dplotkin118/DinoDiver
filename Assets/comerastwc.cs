using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comerastwc : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject NormalCam;
    public GameObject BossCam;
    public GameObject door;
    public GameObject trigger;
    public GameObject boss;
    public GameObject light1;

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
            light1.SetActive(true);
            NormalCam.SetActive(false);
            BossCam.SetActive(true);
            door.SetActive(true);
            trigger.SetActive(false);
        }
    }
}
