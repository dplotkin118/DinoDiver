using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject winScreenUI;

    void Start()
    {
      winScreenUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
      if(Globals.bones_count == 10) {
        winScreenUI.SetActive(true);
        Time.timeScale = 0f;
      }
    }

    public void QuitGame()
    {
            Debug.Log("Quitting Game...");
            Application.Quit();
    }

    // public void Freeplay()
    // {
    //   Globals.bones_count = 0;
    //   winScreenUI.SetActive(false);
    //   Time.timeScale = 1f;
    // }
}
