using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back : MonoBehaviour
{
    public GameObject Shop;
    public GameObject Bones;
    public GameObject OldButton;


    public void CloseShop()
    {
        if (Shop != null)
        {
            Shop.SetActive(false);
        }
    }

    public void OpenBones()
    {
        if (Bones != null)
        {
            Bones.SetActive(true);
        }
    }
    public void OpenOldButton()
    {
        if (OldButton != null)
        {
            OldButton.SetActive(true);
        }
    }
}
