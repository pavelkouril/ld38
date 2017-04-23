using RUF.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Teleport : MonoBehaviour
{
    public LevelManager levelManager;
    public ParticleSystem Particles;

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
            Particles.gameObject.SetActive(true);
            Particles.Play();
            yield return new WaitForSeconds(2);
            levelManager.LevelComplete();
        }
    }
}
