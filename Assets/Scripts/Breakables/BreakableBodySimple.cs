using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RUF.Breakables
{
    [RequireComponent(typeof(Rigidbody))]
    public class BreakableBodySimple : MonoBehaviour
    {
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Destroyer"))
            {
                ApplyGravityOnBody(GetComponent<Rigidbody>());
            }
        }

        private void ApplyGravityOnBody(Rigidbody body)
        {
            body.isKinematic = false;
            body.useGravity = true;
        }
    }
}