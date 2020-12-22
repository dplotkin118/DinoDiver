using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class playerMovement : MonoBehaviour
{


  public Transform Gun;
  public Image bar;
  public Image bar2;
  public Image bar3;
  private SpriteRenderer barSR;
  private Rigidbody2D rb;
  public Animator anim;

  public static bool CanMove = true;
  public static bool facingRight = true;

  public AudioSource coinSound;
  public AudioSource oof;
  public AudioSource boneSound;

  public GameObject MainMenu;
  public GameObject GemCount;
  public GameObject DivingUI;
  public GameObject TeleportLocation;
  public GameObject drownedScreen;
  public Transform gem;
  public Transform bones;
  public GameObject bossCamTrigger;
  public GameObject MainCam;
  public GameObject BossCam;
  public GameObject boss;
  public GameObject rock;
  public GameObject bubble;
  public GameObject lantern;
  public GameObject Angler;
  public GameObject anglerTeleport;
  public GameObject playerHat;
  public GameObject light1;

  public static bool isGameWon = false;

  public static List<Vector2> gemLocations = new List<Vector2>();
  public static int dayGems = 0;
  public static List<GameObject> bonesCollected = new List<GameObject>();
  public static int dayBones = 0;

  private bool isInvincible = false;







  //public TextMeshProUGUI dayText;

  Color lightBlue = new Color(.2814169f, 0.7629005f, 8773585f, 1);

  void Flip()
  {
    facingRight = !facingRight;
    transform.Rotate(Vector3.up * 180);
    Gun.transform.Rotate(Vector3.up * 180);
    lantern.transform.Rotate(Vector3.up * 180);
  }


  void Start()
  {
    facingRight = true;
    anim = gameObject.GetComponent<Animator>();
    transform.position = TeleportLocation.transform.position;
    CanMove = false;
    Scene scene = SceneManager.GetActiveScene();
    rb = GetComponent<Rigidbody2D>();
    oof.GetComponent<AudioSource>().time = oof.GetComponent<AudioSource>().clip.length * .2f;
    if(Globals.isBought8)
    {
      playerHat.SetActive(true);
    }
  }
  void Update()
 {

   //lantern.transform.position = transform.position;
   if(Globals.isBought8)
   {
     playerHat.SetActive(true);
   }
   if(Globals.isBought && !Globals.isBought2)
   {
     bar.sprite = bar2.sprite;
   }
   else if(Globals.isBought2)
   {
     bar.sprite = bar3.sprite;
   }
    if(CanMove)
    {
      anim.SetBool("Swim", true);
      Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
      transform.position = transform.position + movement * Time.deltaTime * 4;


     if(Input.GetAxis("Horizontal") < 0 && facingRight) Flip();
     if(Input.GetAxis("Horizontal") > 0 && !facingRight) Flip();
    }
    else{
      anim.SetBool("Swim", false);
    }

    if(CanMove){
      if(bar.fillAmount == 0f)
      {
        StartCoroutine("DrownScreen");
        rb.velocity = Vector3.zero;
        if(SceneManager.GetActiveScene().name == "Cave Section")
        {
          light1.SetActive(false);
        }
        for(int i = 0; i < gemLocations.Count; i++)
        {
          Instantiate(gem, gemLocations[i], Quaternion.identity);
        }
        for(int i = 0; i < bonesCollected.Count; i++)
        {
          bonesCollected[i].SetActive(true);
          //Instantiate(bones, bonesCollected[i], Quaternion.identity);
        }
        if(Angler != null)
        {
          Angler.transform.position = anglerTeleport.transform.position;
        }
        Globals.canMoveAngler = false;
        Globals.canMovePuffer = false;
        ScoreManager.instance.ChangeBone(-dayBones);
        ScoreManager.instance.ChangeGem(-dayGems);
        gemLocations = new List<Vector2>();
        bonesCollected = new List<GameObject>();
        dayBones = 0;
        dayGems = 0;
        //Resurface.dayCount ++;
        CanMove = false;
        shoot.canShoot = false;
        shootSonar.canShootSonar = false;
        if(!facingRight){
          Flip();
        }
      }
    }

 }

 void OnTriggerEnter2D(Collider2D other)
 {
     if (other.gameObject.CompareTag("Gem"))
     {
         Rigidbody2D gemRigid = other.GetComponent<Rigidbody2D>();
         dayGems++;
         gemLocations.Add(gemRigid.transform.position);
         coinSound.Play(0);
         Destroy(other.gameObject);
     }

     if (other.gameObject.CompareTag("Bone1")||other.gameObject.CompareTag("Bone2")||other.gameObject.CompareTag("Bone3")
     ||other.gameObject.CompareTag("Bone4")||other.gameObject.CompareTag("Bone5")||other.gameObject.CompareTag("Bone6")
     ||other.gameObject.CompareTag("Bone7")||other.gameObject.CompareTag("Bone8")
     ||other.gameObject.CompareTag("Bone9")||other.gameObject.CompareTag("Bone10"))
     {
         bonesCollected.Add(other.gameObject);
         dayBones++;
         other.gameObject.SetActive(false);
     }
     if (other.gameObject.CompareTag("Pufferfish"))
     {
       if(isInvincible == false)
       {
         bar.fillAmount -= .1f;
         oof.Play(0);
       }
       StartCoroutine("InvinciblityFrames", .2f);

     }
     if (other.gameObject.CompareTag("Bubble"))
     {
       bar.fillAmount = 1f;
       other.gameObject.SetActive(false);
     }
     if (other.gameObject.CompareTag("Shark"))
     {
       if(isInvincible == false)
       {
         bar.fillAmount -= .15f;
         oof.Play(0);
       }
       StartCoroutine("InvinciblityFrames", .1f);
     }
     if (other.gameObject.CompareTag("Angler"))
     {
       if(isInvincible == false)
       {
         bar.fillAmount -=.1f;
         oof.Play(0);
       }
       StartCoroutine("InvinciblityFrames", .2f);

     }



 }

 void OnCollisionEnter2D(Collision2D other)
 {
   if(other.gameObject.CompareTag("Sonar") ||other.gameObject.CompareTag("Bullet"))
   {
     Destroy(other.gameObject);
   }
 }

 IEnumerator DrownScreen(){
   drownedScreen.SetActive(true);
   transform.position = TeleportLocation.transform.position;
   MainCam.SetActive(true);
   BossCam.SetActive(false);
   yield return new WaitForSeconds(2f);
   GetComponent<SpriteRenderer>().color = Color.white;
   MainMenu.SetActive(true);
   GemCount.SetActive(false);
   DivingUI.SetActive(false);
   shoot.canShoot = false;
   shootSonar.canShootSonar = false;
   //dayText.text = "Day: " + Resurface.dayCount.ToString();
  BossDefeat.spawnWeenies = false;
   rock.SetActive(false);
   if(boss != null)
   {
     boss.SetActive(false);
   }
   bubble.SetActive(true);
   bossCamTrigger.SetActive(true);
   drownedScreen.SetActive(false);
 }

 IEnumerator InvinciblityFrames(float time)
 {
   isInvincible = true;
   yield return new WaitForSeconds(time);
   isInvincible = false;
 }


}
