using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopOpen : MonoBehaviour
{

    public GameObject Shop;
    public GameObject GemCount;
    public GameObject MainMenu;


    public void OpenShop()
    {
        if(Shop != null)
        {
            Shop.SetActive(true);
        }
    }
    public void OpenGemCount()
    {
        if (GemCount != null)
        {
            GemCount.SetActive(true);
        }
    }
    public void CloseMainMenu()
    {
        if (MainMenu != null)
        {
            MainMenu.SetActive(false);
        }
    }
}
