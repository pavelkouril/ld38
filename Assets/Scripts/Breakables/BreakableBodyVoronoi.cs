using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RUF.Breakables
{
    public class BreakableBodyVoronoi : MonoBehaviour
    {
        public GameObject OriginalObject;
        public GameObject ReplaceObject;
        private List<Rigidbody> mBodies;
        private List<float> mOffsets;
        private List<GameObject> fractures = new List<GameObject>();

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Destroyer"))
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
                        fractures.Add(rb.gameObject);
                        mOffsets.Add(Time.time + Random.value * 1.25f);
                    }
                    else
                    {
                        Destroy(gameObject.GetComponent<Rigidbody>());
                        Destroy(gameObject.GetComponent<Collider>());
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

            if (fractures.Count > 0)
            {
                for (int i = fractures.Count - 1; i >= 0; i--)
                {
                    if (fractures[i].transform.position.y < -40)
                    {
                        Destroy(fractures[i]);
                        fractures.RemoveAt(i);
                    }
                }
            }
        }
    }
}