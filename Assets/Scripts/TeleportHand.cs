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
            var angle = (Force + Acc * 5);
            if (angle > 5f)
            {
                angle = 5f;
            }
            transform.Rotate(0, angle * Time.deltaTime, 0);
        }
    }
}
