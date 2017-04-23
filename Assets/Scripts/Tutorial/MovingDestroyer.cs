using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RUF.Tutorial
{
    public class MovingDestroyer : MonoBehaviour
    {
        public Transform target;

        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * 5);
        }
    }
}