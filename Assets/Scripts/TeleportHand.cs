using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportHand : MonoBehaviour
{
    public bool IsAnimating = false;

    // Update is called once per frame
    void Update()
    {       
        if (IsAnimating)
        {
            Debug.Log("IsAnimating");

        }
    }
}
