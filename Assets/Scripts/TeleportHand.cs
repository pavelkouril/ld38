using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportHand : MonoBehaviour
{
    public bool IsAnimating = false;
    public float Force;
    public float Acc;

    // Update is called once per frame
    void Update()
    {       
        if (IsAnimating)
        {
            Force = (Force + Acc / 4);
            if (Force > 1500)
            {
                Force = 1500;
            }
            transform.Rotate(0, Force * Time.deltaTime, 0);
        }
    }
}
