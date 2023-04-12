using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GetPhantom : MonoBehaviour
{
    GameObject[] Phantom;

    private void Start()
    {
        Phantom = GameObject.FindGameObjectsWithTag("Phantom");
    }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GetComponentInChildren<Rigidbody>().useGravity = true;
            foreach (var child in Phantom)
            {
                child.AddComponent<BoxCollider>();
                child.GetComponent<Rigidbody>().useGravity = true;
            }
            gameObject.GetComponent<RotateCollectibles>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
