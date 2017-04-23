﻿using RUF;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using RUF.Managers;

public class UIManager : MonoBehaviour
{
    public bool AllowKeyInputs { get; set; }

    public GameObject ColorPanel;
    public Text timeRemaingText;
    public Image color;
    public Image nextColor;
    public PlayerColor playerColor;

    private List<string> dieTexts = new List<string>()
         {
        "Git gud.",
        "Ohh, let's try it again, shall we?",
        "(insert funny remark)",
        "(intentionally left blank)",
    };

    public GameObject DiePanel;
    public Text DieTextFlavor;

    public bool CanRestartLevel { get; set; }

    public GameObject IntroTextPanel;
    public Text IntroTextText;
    public List<string> IntroTexts = new List<string>();

    public GameObject PauseMenu;

    public bool PreventPauseMenu { get; set; }

    public GameObject LevelComplete;

    private LevelManager levelManager;

    private void Awake()
    {
        levelManager = GetComponent<LevelManager>();
    }

    private void Start()
    {
        CanRestartLevel = false;
        PauseMenu.SetActive(false);
        if (IntroTexts.Count > 0)
        {
            IntroTextPanel.SetActive(true);
            Time.timeScale = 0;
            ShowBeggining(0);
            AllowKeyInputs = false;
        }
        else
        {
            Time.timeScale = 1;
            AllowKeyInputs = true;
            IntroTextPanel.SetActive(false);
        }
    }

    void Update()
    {
        if (ColorPanel)
        {
            color.color = ForceFieldColors.ConvertToColor(playerColor.FFColor);
            nextColor.color = ForceFieldColors.ConvertToColor(playerColor.NextColor);
            timeRemaingText.text = playerColor.RemainingTime.ToString("0.0");
        }
        if (Input.GetButtonUp("Cancel"))
        {
            if (!AllowKeyInputs)
            {
                LeanTween.alpha(IntroTextPanel.GetComponent<RectTransform>(), 0, 1).setUseEstimatedTime(true).setOnComplete(() =>
                {
                    IntroTextPanel.SetActive(false);
                    AllowKeyInputs = true;
                    Time.timeScale = 1;
                });
            }
            else if (!PreventPauseMenu && !PauseMenu.activeSelf)
            {
                PauseGame();
            }
            else if (!PreventPauseMenu && PauseMenu.activeSelf)
            {
                ResumeGame();
            }
        }
    }

    public void PauseGame()
    {
        PauseMenu.SetActive(true);
        PauseMenu.GetComponentInChildren<Button>().Select();
        Time.timeScale = 0;
        LeanTween.alpha(PauseMenu.GetComponent<RectTransform>(), 0.75f, 1).setUseEstimatedTime(true).setOnComplete(() =>
        {
        });
    }

    public void ResumeGame()
    {
        LeanTween.alpha(PauseMenu.GetComponent<RectTransform>(), 0, 1).setUseEstimatedTime(true).setOnComplete(() =>
        {
            PauseMenu.SetActive(false);
            Time.timeScale = 1;
        });
    }

    public void ShowCompleteScreen()
    {
        LevelComplete.SetActive(true);
        ColorPanel.SetActive(false);
        LeanTween.alpha(LevelComplete.GetComponent<RectTransform>(), 1, 6).setUseEstimatedTime(true).setOnComplete(() =>
        {
            levelManager.LoadNextLevel();
        });
    }

    public void ShowDieScreen()
    {
        DiePanel.SetActive(true);
        DieTextFlavor.text = dieTexts[UnityEngine.Random.Range(0, dieTexts.Count)];
        LeanTween.alpha(DiePanel.GetComponent<RectTransform>(), 1, 1).setUseEstimatedTime(true).setOnComplete(() =>
        {
            CanRestartLevel = true;
        });
    }

    public void ShowBeggining(int i)
    {
        if (i < IntroTexts.Count)
        {
            IntroTextText.text = IntroTexts[i];
            LeanTween.alpha(IntroTextText.GetComponent<RectTransform>(), 1, 1.5f).setUseEstimatedTime(true).setOnComplete(() =>
               {
                   LeanTween.alpha(IntroTextText.GetComponent<RectTransform>(), 0, 1.5f).setUseEstimatedTime(true).setOnComplete(() =>
               {
                   ShowBeggining(i + 1);
               });
               });
        }
        else
        {
            LeanTween.alpha(IntroTextPanel.GetComponent<RectTransform>(), 0, 1).setUseEstimatedTime(true).setOnComplete(() =>
            {
                IntroTextPanel.SetActive(false);
                AllowKeyInputs = true;
                Time.timeScale = 1;
            });
        }
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
