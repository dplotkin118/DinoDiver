using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public Transform Gun;

    Vector2 direction;

    public GameObject Bullet;
    public float BulletSpeed;
    public Transform ShootPoint;
    public float fireRate;
    float ReadyForNextShot;
    public static bool canShoot;
    public AudioSource harpoonSound;
    public bool isHarpoon2;
    public bool isHarpoon3;
    public bool isHarpoon;



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if(canShoot)
      {

        if(playerMovement.facingRight == true)
        {

          Gun.transform.localScale = new Vector2(1,1);
          Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
          direction = mousePos - (Vector2)Gun.position;
          FaceMouse();
        }
        else if(playerMovement.facingRight == false)
        {

          Gun.transform.localScale = new Vector2(-1,1);
          Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
          direction = (Vector2)Gun.position - mousePos;
          FaceMouse();
        }
        if(Input.GetMouseButton(0))
        {
          if(Time.time > ReadyForNextShot && playerMovement.facingRight == true)
          {
            ReadyForNextShot = Time.time + 1/fireRate;
            if(isHarpoon)
            {
              shootBullet();
            }
            if(isHarpoon2)
            {
              shootSecond();
            }
            if(isHarpoon3)
            {
              shootThird();
            }
            harpoonSound.Play(0);
          }
          if(Time.time > ReadyForNextShot && playerMovement.facingRight == false)
          {
            ReadyForNextShot = Time.time + 1/fireRate;
            if(isHarpoon)
            {
              shootBulletLeft();
            }
            if(isHarpoon2)
            {
              shootBulletLeft2();
            }
            if(isHarpoon3)
            {
              shootBulletLeft3();
            }
            harpoonSound.Play(0);
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
      BulletIns.transform.localScale = new Vector2(.3f,.3f);
      BulletIns.GetComponent<Rigidbody2D>().AddForce(BulletIns.transform.right * BulletSpeed);
    }
    void shootSecond()
    {
      GameObject BulletIns2 = Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
      BulletIns2.transform.localScale = new Vector2(.3f,.3f);
      BulletIns2.GetComponent<Rigidbody2D>().AddForce(BulletIns2.transform.right * BulletSpeed);
    }
    void shootThird()
    {
      GameObject BulletIns3 = Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
      BulletIns3.transform.localScale = new Vector2(.3f,.3f);
      BulletIns3.GetComponent<Rigidbody2D>().AddForce(BulletIns3.transform.right * BulletSpeed);
    }
    void shootBulletLeft()
    {
      GameObject BulletIns = Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
      BulletIns.transform.localScale = new Vector2(-.3f,.3f);
      BulletIns.GetComponent<Rigidbody2D>().AddForce(BulletIns.transform.right * -BulletSpeed);
    }
    void shootBulletLeft2()
    {
      GameObject BulletIns2 = Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
      BulletIns2.transform.localScale = new Vector2(-.3f,.3f);
      BulletIns2.GetComponent<Rigidbody2D>().AddForce(BulletIns2.transform.right * -BulletSpeed);
    }
    void shootBulletLeft3()
    {
      GameObject BulletIns3 = Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
      BulletIns3.transform.localScale = new Vector2(-.3f,.3f);
      BulletIns3.GetComponent<Rigidbody2D>().AddForce(BulletIns3.transform.right * -BulletSpeed);
    }
}
