using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] GameObject otherPortal;
    private GameObject player;


    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = otherPortal.transform.position;
        Debug.Log(other.transform.position.x + " " + other.transform.position.y + " " + other.transform.position.z);
    }

}
