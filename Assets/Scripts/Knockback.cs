using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Knockback : MonoBehaviour
{

  public float thrust = 3f;
  public float knockTime = .2f;
  public float health = 100;
  public GameObject Pufferfish;
  public static bool isAlivePuffer = true;
  //public Image bar;
  private float currentHealth;

  void Start()
  {
    isAlivePuffer = true;
  }

  void OnEnable()
  {
    currentHealth = health;
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if(other.gameObject.CompareTag("Player"))
    {
      Rigidbody2D Player = other.GetComponent<Rigidbody2D>();

      //if(bar.fillAmount >= .08f){
        Vector2 difference = Player.transform.position - transform.position;
        difference = difference.normalized * thrust;
        Player.AddForce(difference, ForceMode2D.Impulse);
        StartCoroutine("FlashRedPlayer",other.gameObject);
        StartCoroutine("KnockCo",Player);
        if(isAlivePuffer == false)
        {
          StartCoroutine("KnockCo",Player);
            StartCoroutine("FlashRedPlayer",other.gameObject);
        }

      //}

    }
    if(other.gameObject.CompareTag("Bullet"))
    {
      TakeDamage(20, Pufferfish);
      Destroy(other.gameObject);
    }
    if(other.gameObject.CompareTag("SilverBullet"))
    {
      TakeDamage(40, Pufferfish);
      Destroy(other.gameObject);
    }
    if(other.gameObject.CompareTag("GoldBullet"))
    {
      TakeDamage(60,Pufferfish);
      Destroy(other.gameObject);
    }

  }


  private IEnumerator KnockCo(Rigidbody2D Player)
  {
    yield return new WaitForSeconds(knockTime);
    Player.velocity = Vector2.zero;
  }

  void Update()
  {
    if(currentHealth <= 0)
    {
      StartCoroutine("DeathCoroutine", Pufferfish);
    }
  }

  IEnumerator FlashRed(GameObject Pufferfish)
  {
    Pufferfish.GetComponent<SpriteRenderer>().color = Color.red;
    yield return new WaitForSeconds(.1f);
    Pufferfish.GetComponent<SpriteRenderer>().color = Color.white;
  }
  IEnumerator FlashRedPlayer(GameObject Player)
  {
    Player.GetComponent<SpriteRenderer>().color = Color.red;
    yield return new WaitForSeconds(.1f);
    Player.GetComponent<SpriteRenderer>().color = new Color(.2814169f, 0.7629005f, 8773585f, 1);
  }

  IEnumerator DeathCoroutine(GameObject Pufferfish)
  {
    yield return new WaitForSeconds(knockTime);
    Destroy(Pufferfish);
  }

  public void TakeDamage(float damage, GameObject enemy)
  {
    currentHealth -= damage;
    StartCoroutine(FlashRed(enemy));
  }
}
