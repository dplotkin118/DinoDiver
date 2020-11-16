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
        Player.transform.position = TeleportLocation.transform.position;
        Time.timeScale = 1f;
    }
}
