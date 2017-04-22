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
                collider.size = collider.size - new Vector3(1, 1, 1);
                yield return new WaitForSeconds(1.5f);
            }
        }
    }
}