using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyPufferfish : MonoBehaviour
{
    float destroyTime = 5f;
    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, destroyTime);
        Knockback.isAlivePuffer = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
      if(other.gameObject.CompareTag("Player"))
      {
        StartCoroutine("DeathCoroutine", gameObject);
        Knockback.isAlivePuffer = false;
      }
    }

    IEnumerator DeathCoroutine(GameObject Pufferfish)
    {
      yield return new WaitForSeconds(.2f);
      Destroy(Pufferfish);
    }
}
