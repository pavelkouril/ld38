using RUF;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text timeRemaingText;
    public Image color;
    public Image nextColor;
    public PlayerColor playerColor;

    // Update is called once per frame
    void Update()
    {
        color.color = ForceFieldColors.ConvertToColor(playerColor.FFColor);
        nextColor.color = ForceFieldColors.ConvertToColor(playerColor.NextColor);
        timeRemaingText.text = playerColor.RemainingTime.ToString("0.0");
    }
}
