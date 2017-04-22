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
            Debug.Log("IsAnimating");

            StartCoroutine(Animate());
        }
    }

    private IEnumerator Animate()
    {
        while (true)
        {
            transform.Rotate(0, Mathf.Max(0.001f, Force / 1000 + Acc / 100), 0);

            yield return new WaitForSeconds(0.05f);
        }
    }
}
