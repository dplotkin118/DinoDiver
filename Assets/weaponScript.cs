using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponScript : MonoBehaviour
{

    int totalWeapons = 1;
    public int weaponIndex;
    public GameObject[] guns;
    public GameObject weaponHolder;
    public GameObject currentWeapon;

    public static bool isHarpoonOwned = false;
    public static bool isHarpoon2Owned = false;
    public static bool isHarpoon3Owned = false;
    public static bool isSonarOwned = false;
    public static bool isTridentOwned = false;
    // Start is called before the first frame update
    void Start()
    {
        isHarpoonOwned = Globals.isBought3;
        isHarpoon2Owned = Globals.isBought4;
        isHarpoon3Owned = Globals.isBought5;
        // isTridentOwned = Globals.isBought6;
        // isSonarOwned = Globals.isBought7;
        totalWeapons = weaponHolder.transform.childCount;
        guns = new GameObject[totalWeapons];

        for(int i = 0; i < totalWeapons; i++)
        {
          guns[i] = weaponHolder.transform.GetChild(i).gameObject;
          guns[i].SetActive(false);
        }

        guns[0].SetActive(true);
        currentWeapon = guns[0];
        weaponIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
      if(isHarpoon2Owned)
      {
        isHarpoonOwned = false;
      }
      if(isHarpoon3Owned)
      {
        isHarpoonOwned = false;
        isHarpoon2Owned = false;
      }

      if(Input.GetKeyDown(KeyCode.Alpha1))
      {
        if(isHarpoonOwned)
        {
          guns[weaponIndex].SetActive(false);
          guns[1].SetActive(true);
          weaponIndex = 1;
        }
        if(isHarpoon2Owned)
        {
          guns[weaponIndex].SetActive(false);
          guns[2].SetActive(true);
          weaponIndex = 2;
        }
        if(isHarpoon3Owned)
        {
          guns[weaponIndex].SetActive(false);
          guns[3].SetActive(true);
          weaponIndex = 3;
        }
      }
      // if(Input.GetKeyDown(KeyCode.Alpha2))
      // {
      //   if(isTridentOwned)
      //   {
      //     guns[weaponIndex].SetActive(false);
      //     guns[4].SetActive(true);
      //     weaponIndex = 4;
      //
      //   }
      // }
      // if(Input.GetKeyDown(KeyCode.Alpha3))
      // {
      //   if(isSonarOwned)
      //   {
      //     guns[weaponIndex].SetActive(false);
      //     guns[5].SetActive(true);
      //     weaponIndex = 5;
      //   }
      //
      // }
    }
}
