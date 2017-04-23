using RUF.Tutorial;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RUF
{
    public class LaunchMovingDestruction : MonoBehaviour
    {
        public MovingDestroyer Destroyer;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Destroyer.enabled = true;
            }
        }
    }
}