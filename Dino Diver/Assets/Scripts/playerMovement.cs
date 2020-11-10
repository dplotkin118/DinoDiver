using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
  public Image bar;

  void Start()
  {
    Scene scene = SceneManager.GetActiveScene();
    Debug.Log("Active scene is" + scene.name);
  }
  void Update()
 {
     Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

     transform.position = transform.position + movement * Time.deltaTime * 5;

     if(bar.fillAmount == 0f)
     {
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
     }
 }

 void OnTriggerEnter2D(Collider2D other)
 {
     if (other.gameObject.CompareTag("Gem"))
     {
         Destroy(other.gameObject);
     }

     if (other.gameObject.CompareTag("Bone"))
     {
         Destroy(other.gameObject);
     }
     if (other.gameObject.CompareTag("Pufferfish"))
     {
       bar.fillAmount -= .1f;
     }
 }

}
