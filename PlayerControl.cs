using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    void Start()
    {
        Time.timeScale = 0f;
    }

    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

        transform.position = transform.position + movement * Time.deltaTime * 5;
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
    }

}
