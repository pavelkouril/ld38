using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RUF
{
    public class PlayerColor : MonoBehaviour
    {
        public ForceFieldColors.Values FFColor;

        private ForceFieldColors.Values nextColor;

        private void Start()
        {
            nextColor = (ForceFieldColors.Values)UnityEngine.Random.Range(0, 3);
            StartCoroutine(SwitchColor());
        }

        private IEnumerator SwitchColor()
        {
            while (true)
            {
                FFColor = nextColor;
                do
                {
                    nextColor = (ForceFieldColors.Values)UnityEngine.Random.Range(0, 3);
                } while (nextColor == FFColor);
                gameObject.layer = ForceFieldColors.ConvertToPlayerPhysicsLayer(FFColor);
                yield return new WaitForSeconds(2);
            }
        }
    }
}