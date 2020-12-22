using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dive : MonoBehaviour
{

    public GameObject MainMenu;
    public GameObject DivingUI;
    public GameObject GemCount;
    public GameObject Player;
    public GameObject TeleportLocation;
    Color lightBlue = new Color(.2814169f, 0.7629005f, 8773585f, 1);


    public void CloseMainMenu()
    {
        if (MainMenu != null)
        {
            MainMenu.SetActive(false);
        }
    }

    public void OpenDivingUI()
    {
        if (DivingUI != null)
        {
            DivingUI.SetActive(true);
        }
    }
    public void OpenGemCount()
    {
        if (GemCount != null)
        {
            GemCount.SetActive(true);
        }
    }
    public void Teleport()
    {
        Globals.canMoveAngler = true;
        Globals.canMovePuffer = true;
        Player.transform.position = TeleportLocation.transform.position;
        Time.timeScale = 1f;
        playerMovement.CanMove = true;
        shoot.canShoot = true;
        shootSonar.canShootSonar = true;
    }

    public void TurnBlue()
    {
      Player.GetComponent<SpriteRenderer>().color = lightBlue;
    }
}
