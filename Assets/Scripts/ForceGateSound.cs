using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceGateSound : MonoBehaviour {

    private bool IsPlaying = false;
    private AudioSource Audio;

    private void Awake()
    {
        Audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Audio.Play();
        }
    }
}
