using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RUF
{
    public class ObjectDestroyer : MonoBehaviour
    {
        private new BoxCollider collider;

        private void Awake()
        {
            collider = GetComponent<BoxCollider>();
        }

        private void Start()
        {
            StartCoroutine(MakeColliderSmaller());
        }

        private IEnumerator MakeColliderSmaller()
        {
            while (true)
            {
                if (collider.size.x > 1)
                {
                    collider.size = collider.size - new Vector3(0.66f, 0.66f, 0.66f);
                }
                else
                {
                    break;
                }
                
                yield return new WaitForSeconds(1.8f);
            }
        }
    }
}