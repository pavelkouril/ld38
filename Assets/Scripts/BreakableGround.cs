using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RUF
{
    public class BreakableGround : MonoBehaviour
    {
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Destroyer"))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                GetComponent<Rigidbody>().useGravity = true;
                GetComponent<Rigidbody>().AddForce(new Vector3(0, Random.value * 100f, 0));
            }
        }
    }
}