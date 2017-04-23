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
            IsPlaying = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IsPlaying = false;
        }
    }

    private void Update()
    {
        if (IsPlaying)
        {
            if (!Audio.isPlaying)
            {
                Audio.Play();
            }

            if (Audio.volume < 0.15)
            {
                Audio.volume += Time.deltaTime * 1f / 10f;
            }
        }
        else
        {
            Audio.volume -= Time.deltaTime * 1f/10f;

            if (Audio.volume <= 0)
            {
                Audio.Stop();
            }
        }
    }
}
