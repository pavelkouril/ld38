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

        private void Start()
        {
            PlayerColorBehavior.enabled = false;
            PlayerColorIndicator.SetActive(false);
            PlayerColorUIPanel.SetActive(false);
            uiManager = GetComponent<UIManager>();
            uiManager.enabled = false;
            SwitchToState(0);
        }

        public void SwitchToState(int tutorialStateNumber)
        {
            if (tutorialStateNumber > TutorialState)
            {
                Time.timeScale = 0;
                TutorialPanel.SetActive(true);
                TutorialState = tutorialStateNumber;
                switch (tutorialStateNumber)
                {
                    case 0:
                        TutorialText.text = "Hey. Your world is getting smaller and smaller, falling to eternal darkness piece by piece.\nEscape it!";
                        break;
                    case 1:
                        TutorialText.text = "But first, you will need to learn some basics.\nTry walking forward using the W key or a left Gamepad joystick.";
                        break;
                    case 2:
                        TutorialText.text = "Good. Really good. You are a natural.\nNow try walking in other directions by using ASD keys (or, again, left Gamepad joystick, duh).";
                        break;
                    case 3:
                        TutorialText.text = "Wow. You even made it behind a corner! Great!\nBut don't worry, the journey is trickier than that. Walk a little bit more.";
                        break;
                    case 4:
                        TutorialText.text = "Totally a walking simulator, right?\nNah. Do you see the force field in front of you? Try to go through it.";
                        break;
                    case 5:
                        TutorialText.text = "Oh, you can't. Fooled you!\nYou will need your color matched to the color of the force field ... done! You can thank me later!";
                        PlayerColorBehavior.enabled = true;
                        PlayerColorIndicator.SetActive(true);
                        PlayerColorBehavior.ForceColor(ForceFieldColors.Values.Purple);
                        break;
                    case 6:
                        TutorialText.text = "\"But there are other colors as well? What should you do now?\", he asked.\nJust wait, the color switches after a while to another one.";
                        PlayerColorBehavior.StartColorSwitching();
                        PlayerColorUIPanel.SetActive(true);
                        uiManager.enabled = true;
                        break;
                    case 7:
                        TutorialText.text = "Yeah, and remember when I told you about the world is falling piece by piece? I wasn't kidding.\nSo ... run, you fool!";
                        AllDestroyer.center = new Vector3(0, 10, 0);
                        MovingDestroy.enabled = true;
                        break;
                    case 8:
                        TutorialText.text = "You made it? Congratulations! (I guess?)/nNow just go into the teleport, and buckle up for the real deal.";
                        break;
                }
            }
        }

        private void Update()
        {
            if (Input.GetButtonUp("Submit"))
            {
                if (TutorialState == 0)
                {
                    SwitchToState(1);
                }
                else
                {
                    Time.timeScale = 1;
                    TutorialPanel.SetActive(false);
                    TutorialText.text = "";
                }
            }
        }
    }
}