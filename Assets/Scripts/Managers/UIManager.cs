using RUF;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour
{
    public Text timeRemaingText;
    public Image color;
    public Image nextColor;
    public PlayerColor playerColor;

    public List<string> DieTexts = new List<string>();

    public GameObject DiePanel;
    public Text DieTextFlavor;

    private bool canRestartLevel;

    void Update()
    {
        color.color = ForceFieldColors.ConvertToColor(playerColor.FFColor);
        nextColor.color = ForceFieldColors.ConvertToColor(playerColor.NextColor);
        timeRemaingText.text = playerColor.RemainingTime.ToString("0.0");
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
            canRestartLevel = true;
        });
    }
}
