using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GetHealth : MonoBehaviour
{
    GameObject[] Health;

    private void Start()
    {
        Health = GameObject.FindGameObjectsWithTag("Health");
    }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GetComponentInChildren<Rigidbody>().useGravity = true;
            foreach (var child in Health)
            {
                child.AddComponent<BoxCollider>();
                child.GetComponent<Rigidbody>().useGravity = true;
            }
            gameObject.GetComponent<RotateCollectibles>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
