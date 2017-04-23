using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RUF.Breakables
{
    public class BreakableForceField : MonoBehaviour
    {
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Destroyer"))
            {
                Destroy(gameObject.GetComponent<Rigidbody>());
                Destroy(gameObject.GetComponentInChildren<ForceField>().gameObject, 0.15f);
                foreach (var c in GetComponentsInChildren<Rigidbody>())
                {
                    ApplyGravityOnBody(c);
                }
            }
        }

        private void ApplyGravityOnBody(Rigidbody body)
        {
            body.isKinematic = false;
            body.useGravity = true;
            body.AddForce(new Vector3(Random.value, -Random.value * 5, Random.value), ForceMode.Impulse);
        }
    }
}