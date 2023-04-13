using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private void Start()
    {

    }

    // v public GameObject hitEffect;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*      GameObject effct = Instantiate(hitEffect, transform.position, Quaternion.identity);
              Destroy(effct, 5f);*/
        if (collision.gameObject.layer == 7 || gameObject.layer == 7)
        {

            Destroy(gameObject);
        }
    }
}
