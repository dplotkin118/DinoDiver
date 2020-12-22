using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;
    public TextMeshProUGUI gem_text;
    public TextMeshProUGUI bone_text;
    public GameObject Harpoon;
    public GameObject Harpoon2;
    public GameObject Harpoon3;
    //public GameObject HarpoonOOS;
    public GameObject CantAfford;
    //public GameObject Sonar;
    //public GameObject SonarOOS;
    //public GameObject Trident;
    public Image harpoon;
    public Image harpoon2;
    public Image harpoon3;
    //public Image sonar;
    //public Image trident;
    public Image O2;
    public Image O3;
    public GameObject controlsUI;
    public GameObject O2Upgrade;
    public GameObject O3Upgrade;
    //public GameObject playerHat;
    public GameObject hatButton;
    public Image hat;
    public GameObject Advice;



    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        controlsUI.SetActive(false);
        bone_text.text = "Bones: " + Globals.bones_count.ToString();
        gem_text.text = "Gems: " + Globals.gems_count.ToString();
        if(Globals.isBought)
        {
          O2Upgrade.SetActive(false);
          DeleteImage(O2);
        }
        if(Globals.isBought2)
        {
          O3Upgrade.SetActive(false);
          DeleteImage(O3);
        }
        if(Globals.isBought3)
        {
          Harpoon.SetActive(false);
          DeleteImage(harpoon);
        }
        if(Globals.isBought4)
        {
          Harpoon.SetActive(false);
          Harpoon2.SetActive(false);
          DeleteImage(harpoon2);
        }
        if(Globals.isBought5)
        {
          Harpoon.SetActive(false);
          Harpoon2.SetActive(false);
          Harpoon3.SetActive(false);
          DeleteImage(harpoon3);
        }
        if(Globals.isBought8)
        {
          hatButton.SetActive(false);
          DeleteImage(hat);
        }
        // if(Globals.isBought7)
        // {
        //   .SetActive(false);
        //   DeleteImage(O2);
        // }
        // if(Globals.isBought8)
        // {
        //   BuyO2Upgrade.SetActive(false);
        //   DeleteImage(O2);
        // }
        // if(Globals.isBought9)
        // {
        //   BuyO2Upgrade.SetActive(false);
        //   DeleteImage(O2);
        // }
    }

    public void ChangeGem(int gemValue)
    {
        Globals.gems_count += gemValue;
        gem_text.text = "Gems: " + Globals.gems_count.ToString();
    }

    public void ChangeBone(int boneValue)
    {
        Globals.bones_count += boneValue;
        bone_text.text = "Bones: " + Globals.bones_count.ToString();
    }

    // public void SonarOutOfStock()
    // {
    //     if (Sonar != null)
    //     {
    //         Sonar.SetActive(false);
    //         SonarOOS.SetActive(true);
    //     }
    // }



    // public void BuyTrident()
    // {
    //     if (Globals.gems_count < 30)
    //     {
    //         StartCoroutine(ShortMessage(CantAfford, 1));
    //     }
    //     else
    //     {
    //       Globals.isBought6 = true;
    //         Globals.gems_count = Globals.gems_count - 30;
    //         gem_text.text = "Gems: " + Globals.gems_count.ToString();
    //         DeleteImage(trident);
    //         Trident.SetActive(false);
    //         weaponScript.isTridentOwned = true;
    //     }
    // }
    public void BuyHarpoon()
    {
        if (Globals.gems_count < 10)
        {
            StartCoroutine(ShortMessage(CantAfford, 1));
        }
        else
        {
          StartCoroutine("SomeAdvice", Advice);
            Globals.isBought3 = true;
            Globals.gems_count = Globals.gems_count - 10;
            gem_text.text = "Gems: " + Globals.gems_count.ToString();
            DeleteImage(harpoon);
            Harpoon.SetActive(false);
            weaponScript.isHarpoonOwned = true;
        }
    }
    public void BuySecondHarpoon()
    {
        if (Globals.gems_count < 25)
        {
            StartCoroutine(ShortMessage(CantAfford, 1));
        }
        else
        {
          StartCoroutine("SomeAdvice", Advice);
          Globals.isBought4 = true;
            Globals.gems_count = Globals.gems_count - 25;
            gem_text.text = "Gems: " + Globals.gems_count.ToString();
            DeleteImage(harpoon2);
            if(Harpoon != null)
            {
              Harpoon.SetActive(false);
            }
            Harpoon2.SetActive(false);
            weaponScript.isHarpoon2Owned = true;
        }
    }
    public void BuyThirdHarpoon()
    {
        if (Globals.gems_count < 50)
        {
            StartCoroutine(ShortMessage(CantAfford, 1));
        }
        else
        {
          StartCoroutine("SomeAdvice", Advice);
          Globals.isBought5 = true;
            Globals.gems_count = Globals.gems_count - 50;
            gem_text.text = "Gems: " + Globals.gems_count.ToString();
            if(Harpoon != null)
            {
              Harpoon.SetActive(false);
            }
            if(Harpoon2 != null)
            {
              Harpoon2.SetActive(false);
            }
            DeleteImage(harpoon3);
            Harpoon3.SetActive(false);
            weaponScript.isHarpoon3Owned = true;
        }
    }

    // public void BuySonar()
    // {
    //     if (Globals.gems_count < 20)
    //     {
    //         StartCoroutine(ShortMessage(CantAfford, 1));
    //     }
    //     else
    //     {
    //         Globals.gems_count = Globals.gems_count - 20;
    //         gem_text.text = "Gems: " + Globals.gems_count.ToString();
    //         DeleteImage(sonar);
    //         SonarOutOfStock();
    //         weaponScript.isSonarOwned = true;
    //     }
    // }

    public void openControls(){
      controlsUI.SetActive(true);
    }

    public void backControls(){
      controlsUI.SetActive(false);
    }

    public void BuyO2Upgrade(){
      if(Globals.gems_count < 15)
      {
        StartCoroutine(ShortMessage(CantAfford, 1));
      }
      else{
        Globals.isBought = true;
        Globals.gems_count = Globals.gems_count - 15;
        gem_text.text = "Gems: " + Globals.gems_count.ToString();
        breathingTrigger.isUpgradedOnce = true;
        O2Upgrade.SetActive(false);
        DeleteImage(O2);
      }
    }

    public void BuyO3Upgrade(){
      if(Globals.gems_count < 30)
      {
        StartCoroutine(ShortMessage(CantAfford, 1));
      }
      else{
        Globals.isBought2 = true;
        Globals.gems_count = Globals.gems_count - 30;
        gem_text.text = "Gems: " + Globals.gems_count.ToString();
        breathingTrigger.isUpgradedOnce = false;
        breathingTrigger.isUpgradedTwice = true;
        if(O2Upgrade != null)
        {
          O2Upgrade.SetActive(false);
        }
        O3Upgrade.SetActive(false);
        DeleteImage(O3);
      }
    }

    public void BuyHat()
    {
      if(Globals.gems_count < 5)
      {
        StartCoroutine(ShortMessage(CantAfford, 1));
      }
      else{
        Globals.isBought8 = true;
        Globals.gems_count = Globals.gems_count - 5;
        gem_text.text = "Gems: " + Globals.gems_count.ToString();
        hatButton.SetActive(false);
        DeleteImage(hat);
      }
    }

    IEnumerator ShortMessage(GameObject go, int time)
    {
        go.SetActive(true);
        yield return new WaitForSeconds(time);
        go.SetActive(false);
    }
    IEnumerator SomeAdvice(GameObject other)
    {
      other.SetActive(true);
      yield return new WaitForSeconds(4f);
      other.SetActive(false);
    }

    public void DeleteImage(Image image){
      Destroy(image);
    }
}
