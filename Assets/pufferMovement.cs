using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pufferMovement : MonoBehaviour
{
    public float speed;
    public bool MoveRight;

    // Use this for initialization
    void Update () {
      // Use this for initialization
      if(MoveRight) {
        transform.Translate(2* Time.deltaTime * speed, 0,0);
        if(gameObject.CompareTag("Shark"))
        {
          transform.localScale= new Vector3 (-1.5f,1.5f,1);
        }
        else{
          transform.localScale= new Vector2 (-.5f,.5f);
        }

      }
      else{
        transform.Translate(-2* Time.deltaTime * speed, 0,0);
        if(gameObject.CompareTag("Shark"))
        {
          transform.localScale= new Vector3 (1.5f,1.5f,1);
        }
        else{
          transform.localScale= new Vector2 (.5f,.5f);
        }

      }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
      if (other.gameObject.CompareTag("Turn")){

        if (MoveRight){
          MoveRight = false;
        }
        else{
          MoveRight = true;
        }
      }
}
}
