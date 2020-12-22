using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finalBoss : MonoBehaviour
{

    public GameObject MainCam;
    public GameObject BossCam;
    public GameObject door;
    public GameObject bubble;
    public GameObject boss;
    public Image bar;
    public Transform children_prefab;
    public Transform children_prefab1;
    public Transform children_prefab2;
    public float bossHealth;
    public static bool spawnWeenies;
    public GameObject bone1;
    public GameObject bone2;
    public GameObject light1;

    // Start is called before the first frame update
    void Start()
    {


    }
    void Awake()
    {
      spawnWeenies = true;
      // bossHealth = 300;

    }
    void OnEnable()
    {
      InvokeRepeating("SpawnChildren", 1f, 3f);
      InvokeRepeating("SpawnChildren1", 1.5f, 2f);
      InvokeRepeating("SpawnChildren2", 2f, 2f);
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
          Destroy(boss);
          bone1.SetActive(true);
          bone2.SetActive(true);
          light1.SetActive(false);

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
      Instantiate(children_prefab, new Vector2(Random.Range(33,40),Random.Range(-20f, -13f)), Quaternion.identity);
      children_prefab.tag = "Pufferfish";
      children_prefab.localScale = new Vector3(.5f,.5f,.5f);
    }
    void SpawnChildren1()
    {
      Instantiate(children_prefab1, new Vector2(Random.Range(33,40),Random.Range(-20f, -13f)), Quaternion.identity);
      children_prefab.tag = "Shark";
      children_prefab.localScale = new Vector3(1.5f,1.5f,1f);
    }
    void SpawnChildren2()
    {
      Instantiate(children_prefab2, new Vector2(Random.Range(33,40),Random.Range(-20f, -13f)), Quaternion.identity);
      children_prefab.tag = "Angler";
      children_prefab.localScale = new Vector3(1f,-1f,1f);
    }

    public void TakeDamage(float damage, GameObject enemy)
    {
      bossHealth -= damage;
      StartCoroutine(FlashRed(enemy));
    }
}
