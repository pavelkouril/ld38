using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RUF
{
    public class BreakableGround : MonoBehaviour
    {
        private void OnTriggerExit(Collider other)
        {
            Debug.Log("collide");
            if (other.CompareTag("Destroyer"))
            {
                Debug.Log("collide");
                Destroy(this.gameObject);
            }
        }
    }
}