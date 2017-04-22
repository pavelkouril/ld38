using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RUF
{
    public class BreakableBody : MonoBehaviour
    {
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Destroyer"))
            {
                var body = GetComponent<Rigidbody>();
                if (tag == "Wall")
                {
                    var coroutine = ApplyGravityCouritine(body);
                    StartCoroutine(coroutine);
                }
                else
                {
                    ApplyGravityOnBody(body);
                }
            }
        }

        private void ApplyGravityOnBody(Rigidbody body)
        {
            body.isKinematic = false;
            body.useGravity = true;
            body.AddForce(new Vector3(0, Random.value * 100f, 0));
        }

        private IEnumerator ApplyGravityCouritine(Rigidbody wall)
        {
            yield return new WaitForSeconds(1.8f);

            ApplyGravityOnBody(wall);
        }
    }
}