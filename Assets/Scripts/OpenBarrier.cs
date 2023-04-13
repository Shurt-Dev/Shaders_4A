using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBarrier : MonoBehaviour
{
    [SerializeField] GameObject barrier;
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            barrier.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
