using RUF;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public bool AllowKeyInputs { get; set; }

    public GameObject ColorPanel;
    public Text timeRemaingText;
    public Image color;
    public Image nextColor;
    public PlayerColor playerColor;

    public List<string> DieTexts = new List<string>();

    public GameObject DiePanel;
    public Text DieTextFlavor;

    public bool CanRestartLevel { get; set; }

    public GameObject IntroTextPanel;
    public Text IntroTextText;
    public List<string> IntroTexts = new List<string>();

    public GameObject PauseMenu;

    public bool PreventPauseMenu { get; set; }

    private void Start()
    {
        CanRestartLevel = false;
        PauseMenu.SetActive(false);
        if (IntroTexts.Count > 0)
        {
            IntroTextPanel.SetActive(true);
            ShowBeggining(0);
            AllowKeyInputs = false;
        }
        else
        {
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

    }

    public void ShowDieScreen()
    {
        DiePanel.SetActive(true);
        DieTextFlavor.text = DieTexts[UnityEngine.Random.Range(0, DieTexts.Count)];
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
            });
        }
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
