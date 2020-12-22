using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootSonar : MonoBehaviour
{
    public Transform Gun;

    Vector2 direction;

    public GameObject Bullet;
    public float BulletSpeed;
    public Transform ShootPoint;
    public float fireRate;
    float ReadyForNextShot;
    public static bool canShootSonar;



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(canShootSonar)
        {

          if(playerMovement.facingRight == true)
          {
            Gun.transform.localScale = new Vector2(.5f,.5f);
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = mousePos - (Vector2)Gun.position;
            FaceMouse();
          }
          else if(playerMovement.facingRight == false)
          {

            Gun.transform.localScale = new Vector2(-.5f,.5f);
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = (Vector2)Gun.position - mousePos;
            FaceMouse();
          }
          if(Input.GetMouseButton(0))
          {
            if(Time.time > ReadyForNextShot && playerMovement.facingRight == true)
            {
              ReadyForNextShot = Time.time + 1/fireRate;
              shootBullet();
            }
            if(Time.time > ReadyForNextShot && playerMovement.facingRight == false)
            {
              ReadyForNextShot = Time.time + 1/fireRate;
              shootBulletLeft();
            }

          }
        }

    }

    void FaceMouse()
    {
      Gun.transform.right = direction;

    }

    void shootBullet()
    {
      GameObject BulletIns = Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
      BulletIns.transform.localScale = new Vector2(.2f,.2f);
      BulletIns.GetComponent<Rigidbody2D>().AddForce(BulletIns.transform.right * BulletSpeed);
    }
    void shootBulletLeft()
    {
      GameObject BulletIns = Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
      BulletIns.transform.localScale = new Vector2(-.2f,.2f);
      BulletIns.GetComponent<Rigidbody2D>().AddForce(BulletIns.transform.right * -BulletSpeed);
    }

}
