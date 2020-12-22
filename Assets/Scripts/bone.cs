using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bone : MonoBehaviour
{
    public static int boneValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreManager.instance.ChangeBone(boneValue);
        }
    }

}
