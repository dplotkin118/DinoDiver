using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{

  public enum Modes
  {melee, Straight, Follow, Throw}

  public Sprite sprite;
  public GameObject projectile;
  public float projectileSpeed;
  public float coolDown = 5f;
  public Modes projectileMode;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
