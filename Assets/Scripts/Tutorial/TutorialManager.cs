using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RUF.Tutorial
{
    public class TutorialManager : MonoBehaviour
    {
        public GameObject TutorialPanel;
        public Text TutorialText;
        public PlayerColor PlayerColorBehavior;
        public GameObject PlayerColorIndicator;
        public GameObject PlayerColorUIPanel;
        public BoxCollider AllDestroyer;
        public MovingDestroyer MovingDestroy;

        public int TutorialState = -1;

        private UIManager uiManager;

        private void Awake()
        {
            uiManager = GetComponent<UIManager>();
        }

        private void Start()
        {
            uiManager.PreventPauseMenu = true;
            PlayerColorBehavior.enabled = false;
            PlayerColorIndicator.SetActive(false);
            PlayerColorUIPanel.SetActive(false);
            SwitchToState(0);
        }

        public void SwitchToState(int tutorialStateNumber)
        {
            if (tutorialStateNumber > TutorialState)
            {
                uiManager.PreventPauseMenu = true;
                Time.timeScale = 0;
                TutorialPanel.SetActive(true);
                TutorialState = tutorialStateNumber;
                switch (tutorialStateNumber)
                {
                    case 0:
                        TutorialText.text = "Don't worry; I will help you with escaping from this shithole (and yes, by shithole, I mean your world).";
                        break;
                    case 1:
                        TutorialText.text = "First, you will need to learn some basics.\nTry walking forward using the W key or left Gamepad joystick.";
                        break;
                    case 2:
                        TutorialText.text = "Good. Really good. You are a natural. (Who would have thought?)\nNow try walking in other directions by using ASD keys (or, again, left Gamepad joystick, duh).";
                        break;
                    case 3:
                        TutorialText.text = "Wow. You even made it behind a corner.\nDon't worry, your journey is gonna be trickier than that. Walk a little bit more.";
                        break;
                    case 4:
                        TutorialText.text = "I bet you are thinking this is a walking simulator, right?\nNah. Do you see the force field in front of you? Try to go through it.";
                        break;
                    case 5:
                        TutorialText.text = "Fooled you! You can't; your color will need to match the color of the force field.\nSee your color now? You can thank me later. (Or don't.)";
                        PlayerColorBehavior.enabled = true;
                        PlayerColorIndicator.SetActive(true);
                        PlayerColorBehavior.ForceColor(ForceFieldColors.Values.Purple);
                        break;
                    case 6:
                        TutorialText.text = "\"But there are other colors as well? What should I do now?\", he asked.\nJust wait, the color switches after a while to another one.";
                        PlayerColorBehavior.StartColorSwitching();
                        PlayerColorUIPanel.SetActive(true);
                        break;
                    case 7:
                        TutorialText.text = "Yeah, and remember when I told you about the world falling piece by piece? I wasn't kidding.\nSo ... run, you fool!";
                        AllDestroyer.center = new Vector3(0, 10, 0);
                        MovingDestroy.enabled = true;
                        break;
                    case 8:
                        TutorialText.text = "You made it? Congratulations! /nNow just go into the teleport, and buckle up for the real deal.";
                        break;
                }
            }
        }

        private void Update()
        {
            if (uiManager.AllowKeyInputs && !uiManager.PauseMenu.activeSelf && Input.GetButtonUp("Submit"))
            {
                if (TutorialState == 0)
                {
                    SwitchToState(1);
                }
                else
                {
                    Time.timeScale = 1;
                    TutorialPanel.SetActive(false);
                    uiManager.PreventPauseMenu = false;
                    TutorialText.text = "";
                }
            }
        }
    }
}