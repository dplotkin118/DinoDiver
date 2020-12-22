using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class breathingTrigger : MonoBehaviour
{
  public Image bar;
  public static bool coolingDown = false;
  public static bool isUpgradedOnce = false;
  public static bool isUpgradedTwice = false;
  //float waitTime = 20.0f;

    // Update is called once per frame

    void Start()
    {
      isUpgradedOnce = Globals.isBought;
      isUpgradedTwice = Globals.isBought2;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
      if(other.gameObject.CompareTag("Player")){
        coolingDown = true;
      }

    }
    void OnTriggerExit2D(Collider2D other)
    {
      if(other.gameObject.CompareTag("Player")){
        coolingDown = false;
        bar.fillAmount = 1.0f;
      }

    }
    void Update()
    {
        if (coolingDown == true && isUpgradedOnce == false && isUpgradedTwice == false)
        {
          bar.fillAmount -= 1.0f / 30 * Time.deltaTime;

        }
        if(coolingDown == true && isUpgradedOnce == true)
        {
          bar.fillAmount -= 1.0f / 50 * Time.deltaTime;
        }
        if(coolingDown == true && isUpgradedTwice == true)
        {
          bar.fillAmount -= 1.0f / 90 * Time.deltaTime;
        }

    }

}
