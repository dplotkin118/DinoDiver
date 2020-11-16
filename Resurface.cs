using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resurface : MonoBehaviour
{

    public GameObject MainMenu;
    public GameObject GemCount;
    public GameObject DivingUI;
    public GameObject Player;
    public GameObject TeleportLocation;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject hitObj = collider.gameObject;

        if (hitObj.tag == "Player")
        {
            MainMenu.SetActive(true);
            GemCount.SetActive(false);
            DivingUI.SetActive(false);
            Player.transform.position = TeleportLocation.transform.position;
            Time.timeScale = 0f;
        }
    }
}
