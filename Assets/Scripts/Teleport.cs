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
            Debug.Log("You win, you fool.");
            yield return new WaitForSeconds(0.5f);
            foreach (var c in GetComponents<Collider>())
            {
                c.isTrigger = false;
            }
        }
    }
}
