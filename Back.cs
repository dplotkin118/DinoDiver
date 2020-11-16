using System.Collections.Generic;
using UnityEngine;

public class Back : MonoBehaviour
{

    public GameObject Shop;
    public GameObject GemCount;
    public GameObject MainMenu;


    public void CloseShop()
    {
        if (Shop != null)
        {
            Shop.SetActive(false);
        }
    }
    public void CloseGemCount()
    {
        if (GemCount != null)
        {
            GemCount.SetActive(false);
        }
    }
    public void OpenMainMenu()
    {
        if (MainMenu != null)
        {
            MainMenu.SetActive(true);
        }
    }
}
