using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChildMovement : MonoBehaviour
{

    private GameObject Player;
    public int MoveSpeed = 4;
    public int MinDist = 0;


    void Start()
    {
      Player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        //rotate to look at the player
        if(gameObject.CompareTag("Angler") && Globals.canMoveAngler)
        {
          transform.LookAt(Player.transform.position);
          transform.Rotate(new Vector3(0,-90,0),Space.Self);//correcting the original rotation


          //move towards the player
          if (Vector3.Distance(transform.position,Player.transform.position)<MinDist){//move if distance from target is greater than 1
              transform.Translate(new Vector3(MoveSpeed* Time.deltaTime,0,0) );
          }
        }
        else if(gameObject.CompareTag("Angler") && !Globals.canMoveAngler)
        {

        }
        else{
          if(Globals.canMovePuffer)
          {
            transform.LookAt(Player.transform.position);
            transform.Rotate(new Vector3(0,-90,0),Space.Self);//correcting the original rotation


            //move towards the player
            if (Vector3.Distance(transform.position,Player.transform.position)<MinDist){//move if distance from target is greater than 1
                transform.Translate(new Vector3(MoveSpeed* Time.deltaTime,0,0) );
            }
          }

        }

    }
}
