using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RUF
{
    public class BreakableBody : MonoBehaviour
    {
        public GameObject OriginalObject;
        public GameObject ReplaceObject;

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Destroyer"))
            {
                if (tag == "Wall")
                {
                    ApplyGravityOnBody(GetComponent<Rigidbody>());
                }
                else
                {
                    OriginalObject.SetActive(false);
                    ReplaceObject.SetActive(true);
                    foreach (var rb in GetComponentsInChildren<Rigidbody>())
                    {
                        ApplyGravityOnBody(rb);
                    }
                }
            }
        }

        private void ApplyGravityOnBody(Rigidbody body)
        {
            body.isKinematic = false;
            body.useGravity = true;
            body.AddForce(new Vector3(0, Random.value * 100f, 0));
        }
    }
}