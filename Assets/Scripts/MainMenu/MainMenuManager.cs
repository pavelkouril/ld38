using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RUF.MainMenu
{
    public class MainMenuManager : MonoBehaviour
    {
        public void StartButtonPressed()
        {
            SceneManager.LoadScene("00-Tutorial");
        }

        public void QuitButtonPressed()
        {
            Application.Quit();
        }
    }
}