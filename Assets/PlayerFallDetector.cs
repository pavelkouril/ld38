using RUF.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RUF
{
    public class PlayerFallDetector : MonoBehaviour
    {
        public LevelManager levelManager;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                levelManager.Die();
            }
        }
    }
}