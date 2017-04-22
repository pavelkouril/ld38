using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RUF
{
    public class DestroyByHeight : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player"))
            {
                Destroy(other.gameObject);
            }
        }
    }
}