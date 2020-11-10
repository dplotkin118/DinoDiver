using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class breathingBar : MonoBehaviour
{
  public Image bar;
  public bool coolingDown;
    public float waitTime = 30.0f;

    // Update is called once per frame
    void Update()
    {
        if (coolingDown == true)
        {
            //Reduce fill amount over 30 seconds
            bar.fillAmount -= 1.0f / waitTime * Time.deltaTime;
        }
    }
}
