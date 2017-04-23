using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RUF.MainMenu
{
    public class RandomDestroyer : MonoBehaviour
    {
        public Vector2 XArea;
        public Vector2 ZArea;

        private void Start()
        {
            StartCoroutine(RandomJump());
        }

        private IEnumerator RandomJump()
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(1, 2f));
            while (true)
            {
                transform.position = new Vector3((int)UnityEngine.Random.Range(XArea.x, XArea.y), 0, (int)UnityEngine.Random.Range(ZArea.x, ZArea.y));
                yield return new WaitForSeconds(UnityEngine.Random.Range(2, 4));
            }
        }
    }
}