using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Resurface : MonoBehaviour
{

    public GameObject MainMenu;
    public GameObject GemCount;
    public GameObject DivingUI;
    public GameObject Player;
    public GameObject TeleportLocation;
    public GameObject StayLocation;
    public GameObject Angler;
    public GameObject anglerTeleport;
  //  public GameObject resurfaceUI;

    // public static int dayCount = 1;
    // public TextMeshProUGUI dayText;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject hitObj = collider.gameObject;

        if (hitObj.tag == "Player")
        {
          //resurfaceUI.SetActive(true);
          Globals.canMoveAngler = false;
          Globals.canMovePuffer = false;
          shoot.canShoot = false;
          shootSonar.canShootSonar = false;
          Time.timeScale = 0f;
          //resurfaceUI.SetActive(false);
          Time.timeScale = 1f;
          Player.transform.position = TeleportLocation.transform.position;
          if(Angler != null && anglerTeleport != null)
          {
            Angler.transform.position = anglerTeleport.transform.position;
          }
          MainMenu.SetActive(true);
          GemCount.SetActive(false);
          DivingUI.SetActive(false);
          Player.GetComponent<SpriteRenderer>().color = Color.white;
          playerMovement.CanMove = false;
          //dayCount ++;
          //dayText.text = "Day: " + dayCount.ToString();
          Player.GetComponent<SpriteRenderer>().color = Color.white;
          playerMovement.dayGems = 0;
          playerMovement.gemLocations = new List<Vector2>();
          playerMovement.dayBones = 0;
          playerMovement.bonesCollected = new List<GameObject>();


        }
    }

    // public void Exit(){
    //   resurfaceUI.SetActive(false);
    //   Time.timeScale = 1f;
    //   Player.transform.position = TeleportLocation.transform.position;
    //   MainMenu.SetActive(true);
    //   GemCount.SetActive(false);
    //   DivingUI.SetActive(false);
    //   Player.GetComponent<SpriteRenderer>().color = Color.white;
    //   playerMovement.CanMove = false;
    //   dayCount ++;
    //   dayText.text = "Day: " + dayCount.ToString();
    //   Player.GetComponent<SpriteRenderer>().color = Color.white;
    //   playerMovement.dayGems = 0;
    //   playerMovement.gemLocations = new List<Vector2>();
    //   playerMovement.dayBones = 0;
    //   playerMovement.boneLocations = new List<Vector2>();
    // }

    // public void Stay(){
    //   resurfaceUI.SetActive(false);
    //   Time.timeScale = 1f;
    //   Player.transform.position = StayLocation.transform.position;
    //   shoot.canShoot = true;
    //   shootSonar.canShootSonar = true;
    // }
}
