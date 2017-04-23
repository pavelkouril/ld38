using RUF.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace RUF.MainMenu
{
    public class MainMenuManager : MonoBehaviour
    {
        public Button Level01Button;
        public Button Level02Button;
        public Button Level03Button;
        public Button Level04Button;
        public Button Level05Button;

        private LevelManager levelManager;

        private void Awake()
        {
            levelManager = GetComponent<LevelManager>();
        }

        private void Start()
        {
            var latestLvl = levelManager.ReadSavedLevelNumber();
            Level01Button.interactable = latestLvl > 0;
            Level02Button.interactable = latestLvl > 1;
            Level03Button.interactable = latestLvl > 2;
            Level04Button.interactable = latestLvl > 3;
            Level05Button.interactable = latestLvl > 4;
        }

        public void StartLevel00()
        {
            SceneManager.LoadScene("00");
        }

        public void StartLevel01()
        {
            SceneManager.LoadScene("01");
        }

        public void StartLevel02()
        {
            SceneManager.LoadScene("02");
        }

        public void StartLevel03()
        {
            SceneManager.LoadScene("03");
        }

        public void StartLevel04()
        {
            SceneManager.LoadScene("04");
        }

        public void StartLevel05()
        {
            SceneManager.LoadScene("05");
        }

        public void QuitButtonPressed()
        {
            Application.Quit();
        }
    }
}