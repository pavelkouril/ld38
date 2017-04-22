using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RUF.Tutorial
{
    public class TutorialCheckPoint : MonoBehaviour
    {
        public int TutorialStateNumber = 1;

        private TutorialManager tutorialManager;

        private void Awake()
        {
            tutorialManager = FindObjectOfType<TutorialManager>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                tutorialManager.SwitchToState(TutorialStateNumber);
            }
        }
    }
}