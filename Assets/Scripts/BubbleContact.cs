using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleContact : MonoBehaviour
{
    [SerializeField] GameObject InvincibilityBubble;
    [SerializeField] GameObject HealingBubble;
    private void OnTriggerEnter(Collider Collision)
    {
        if(Collision.gameObject.tag == "ITrigger")
        {
            InvincibilityBubble.SetActive(true);
        }
    }
}
