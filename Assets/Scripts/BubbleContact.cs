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
            StartCoroutine(TimerInvincibility());
        }

        if (Collision.gameObject.tag == "HTrigger")
        {
            StartCoroutine(TimerHealing());
        }
    }

   public IEnumerator TimerInvincibility()
    {
        float duration = 10f;
        InvincibilityBubble.SetActive(true);       
        yield return new WaitForSeconds(duration);
        InvincibilityBubble.SetActive(false);
    }
    public IEnumerator TimerHealing()
    {
        float duration = 2f;
        HealingBubble.SetActive(true);
        yield return new WaitForSeconds(duration);
        HealingBubble.SetActive(false);
    }
}
