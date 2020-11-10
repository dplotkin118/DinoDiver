using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopOpen : MonoBehaviour
{

    public GameObject Shop;
    public GameObject Bones;
    public GameObject OldButton;


    public void OpenShop()
    {
        if(Shop != null)
        {
            Shop.SetActive(true);
        }
    }

    public void CloseBones()
    {
        if (Bones != null)
        {
            Bones.SetActive(false);
        }
    }
    public void CloseOldButton()
    {
        if (OldButton != null)
        {
            OldButton.SetActive(false);
        }
    }
}
