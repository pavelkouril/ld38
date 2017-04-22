using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Teleport : MonoBehaviour
{
    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            yield return new WaitForSeconds(0.5f);
            foreach (var c in GetComponents<Collider>())
            {
                c.isTrigger = false;
            }
            foreach (var hand in GetComponentsInChildren<TeleportHand>())
            {
                hand.IsAnimating = true;
            }
        }
    }
}
