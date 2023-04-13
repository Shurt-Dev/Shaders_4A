using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCollectibles : MonoBehaviour
{

    public float rotationAmount = 2f;
    public int ticksPerSecond = 60;
    public bool Pause = false;

    private void Start()
    {
        StartCoroutine(Rotate());
    }

    public IEnumerator Rotate()
    {
        WaitForSeconds Wait = new WaitForSeconds(1f /  ticksPerSecond);

        while (true)
        {
            if(!Pause) 
            {
                transform.Rotate(Vector3.up * rotationAmount);
            }
            yield return Wait;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Pause = true;
        }
    }
}
