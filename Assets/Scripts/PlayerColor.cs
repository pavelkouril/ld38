using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RUF
{
    public class PlayerColor : MonoBehaviour
    {
        public ForceFieldColors.Values FFColor;
        public float RemainingTime = 0.1f;
        public ForceFieldColors.Values NextColor;

        private void Start()
        {
            NextColor = (ForceFieldColors.Values)UnityEngine.Random.Range(0, 3);
            StartCoroutine(SwitchColor());
        }

        private IEnumerator SwitchColor()
        {
            while (true)
            {
                RemainingTime -= 0.1f;
                if (RemainingTime <= 0)
                {
                    RemainingTime = UnityEngine.Random.Range(2, 3);
                    FFColor = NextColor;
                    do
                    {
                        NextColor = (ForceFieldColors.Values)UnityEngine.Random.Range(0, 3);
                    } while (NextColor == FFColor);
                    gameObject.layer = ForceFieldColors.ConvertToPlayerPhysicsLayer(FFColor);
                }
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}