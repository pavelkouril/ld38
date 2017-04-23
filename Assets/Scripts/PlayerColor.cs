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

        private IEnumerator switchColCoroutine;

        int last0 = 0;
        int last1 = 0;
        int last2 = 0;

        private void Awake()
        {
            switchColCoroutine = SwitchColor();
            NextColor = (ForceFieldColors.Values)UnityEngine.Random.Range(0, 3);
            StartCoroutine(switchColCoroutine);
        }

        public void ForceColor(ForceFieldColors.Values col)
        {
            StopCoroutine(switchColCoroutine);
            FFColor = col;
            gameObject.layer = ForceFieldColors.ConvertToPlayerPhysicsLayer(FFColor);
            do
            {
                NextColor = (ForceFieldColors.Values)UnityEngine.Random.Range(0, 3);
            } while (NextColor == FFColor);
        }

        public void StartColorSwitching()
        {
            StartCoroutine(switchColCoroutine);
        }

        private IEnumerator SwitchColor()
        {
            int i = 1;
            while (true)
            {
                RemainingTime -= 0.1f;
                if (RemainingTime <= 0)
                {
                    RemainingTime = UnityEngine.Random.Range(2f, 3f);
                    FFColor = NextColor;

                    switch (FFColor)
                    {
                        case ForceFieldColors.Values.Cyan:
                            last0 = i;
                            break;
                        case ForceFieldColors.Values.Purple:
                            last1 = i;
                            break;
                        case ForceFieldColors.Values.Yellow:
                            last2 = i;
                            break;
                    }

                    gameObject.layer = ForceFieldColors.ConvertToPlayerPhysicsLayer(FFColor);

                    if (i - last0 >= 4)
                    {
                        NextColor = ForceFieldColors.Values.Cyan;
                    }
                    else if (i - last1 >= 4)
                    {
                        NextColor = ForceFieldColors.Values.Purple;
                    }
                    else if (i - last2 >= 4)
                    {
                        NextColor = ForceFieldColors.Values.Yellow;
                    }
                    else
                    {
                        do
                        {
                            NextColor = (ForceFieldColors.Values)UnityEngine.Random.Range(0, 3);
                        } while (NextColor == FFColor);
                    }
                    i++;
                }
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}