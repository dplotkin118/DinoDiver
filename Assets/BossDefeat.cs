using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossDefeat : MonoBehaviour
{

    public GameObject MainCam;
    public GameObject BossCam;
    public GameObject door;
    public GameObject bubble;
    public GameObject boss;
    public GameObject sign;
    public Image bar;
    public Transform children_prefab;
    public float bossHealth;
    public static bool spawnWeenies;

    // Start is called before the first frame update
    void Start()
    {


    }
    void Awake()
    {
      spawnWeenies = true;

    }
    void OnEnable()
    {
      bossHealth = 300;
      InvokeRepeating("SpawnChildren", 1f, 3f);
    }
    // Update is called once per frame
    void Update()
    {
      if(bar.fillAmount <= .08)
      {
        CancelInvoke();
      }
        if(bossHealth <= 0)
        {
          BossCam.SetActive(false);
          MainCam.SetActive(true);
          door.SetActive(false);
          bubble.SetActive(true);
          sign.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
      if(other.gameObject.CompareTag("Bullet"))
      {
        TakeDamage(20, boss);
        Destroy(other.gameObject);
      }
      if(other.gameObject.CompareTag("GoldBullet"))
      {
        TakeDamage(60, boss);
        Destroy(other.gameObject);
      }
      if(other.gameObject.CompareTag("SilverBullet"))
      {
        TakeDamage(40, boss);
        Destroy(other.gameObject);
      }
    }

    IEnumerator FlashRed(GameObject Pufferfish)
    {
      Pufferfish.GetComponent<SpriteRenderer>().color = Color.red;
      yield return new WaitForSeconds(.1f);
      Pufferfish.GetComponent<SpriteRenderer>().color = Color.white;
    }


    void SpawnChildren()
    {
      Instantiate(children_prefab, new Vector2(-15.3f,-28.7f), Quaternion.identity);
      children_prefab.tag = "Pufferfish";
      children_prefab.localScale = new Vector3(.5f,.5f,.5f);
    }

    public void TakeDamage(float damage, GameObject enemy)
    {
      bossHealth -= damage;
      StartCoroutine(FlashRed(enemy));
    }
}
