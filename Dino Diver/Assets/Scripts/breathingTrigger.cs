using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class breathingTrigger : MonoBehaviour
{
  public Image bar;
  public bool coolingDown = true;
  public float waitTime = 30.0f;

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
      Debug.Log("Triggered");
      coolingDown = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
      Debug.Log("Untriggered");
      coolingDown = false;
      bar.fillAmount = 1.0f;
    }
    void Update()
    {
        if (coolingDown == true)
        {
            //Reduce fill amount over 30 seconds
            bar.fillAmount -= 1.0f / waitTime * Time.deltaTime;
        }
    }

}
