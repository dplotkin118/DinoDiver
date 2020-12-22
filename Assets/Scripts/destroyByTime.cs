using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyByTime : MonoBehaviour
{
    float destroyTime = 2f;
    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, destroyTime);
    }
}
