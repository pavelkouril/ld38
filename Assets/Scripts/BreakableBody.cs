using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RUF
{
    public class BreakableBody : MonoBehaviour
    {
        public GameObject OriginalObject;
        public GameObject ReplaceObject;
        private List<Rigidbody> mBodies;
        private List<float> mOffsets;

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
                    mBodies = new List<Rigidbody>();
                    mOffsets = new List<float>();

                    OriginalObject.SetActive(false);
                    ReplaceObject.SetActive(true);
                    foreach (var rb in GetComponentsInChildren<Rigidbody>())
                    {
                        if (rb.gameObject != gameObject)
                        {
                            rb.isKinematic = true;
                            rb.useGravity = false;
                            mBodies.Add(rb);
                            mOffsets.Add(Time.time + Random.value * 2.5f);
                        }
                        else
                        {
                            Destroy(gameObject.GetComponent<Rigidbody>());
                            Destroy(gameObject.GetComponent<Collider>());
                        }
                    }
                }
            }
        }

        private void ApplyGravityOnBody(Rigidbody body)
        {
            body.isKinematic = false;
            body.useGravity = true;
        }

        private void Update()
        {
            if (mBodies != null && mBodies.Count > 0)
            {
                List<int> remove = new List<int>();

                for (int i = 0; i < mBodies.Count; i++)
                {
                    if (mOffsets[i] <= Time.time)
                    {
                        ApplyGravityOnBody(mBodies[i]);
                        remove.Add(i);
                    }
                }
                
                if (remove.Count == mBodies.Count)
                {
                    mBodies = null;
                }
            }
        }
    }
}