using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GetInvincibility : MonoBehaviour
{
    GameObject[] Kids;

    private void Start()
    {
        Kids = GameObject.FindGameObjectsWithTag("Invincibility");
    }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GetComponentInChildren<Rigidbody>().useGravity = true;
            foreach (var child in Kids)
            {
                child.AddComponent<BoxCollider>();
                child.GetComponent<Rigidbody>().useGravity = true;
            }
            gameObject.GetComponent<RotateCollectibles>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
