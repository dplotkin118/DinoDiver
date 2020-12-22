using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public GameObject noLeavingScreen;

    void OnTriggerEnter2D(Collider2D other)
    {
      if(other.gameObject.CompareTag("Player"))
      {
        if(Globals.bones_count < 4)
        {
          shoot.canShoot = false;
          noLeavingScreen.SetActive(true);
          Time.timeScale = 0f;
        }
        else{
          playerMovement.dayBones = 0;
          playerMovement.dayGems = 0;
          SceneManager.LoadScene("Cave Section");
        }


      }
    }

    public void OKButton()
    {

      Time.timeScale = 1f;
      noLeavingScreen.SetActive(false);
      shoot.canShoot = true;
    }
}
