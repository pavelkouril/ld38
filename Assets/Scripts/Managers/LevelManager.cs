using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RUF.Managers
{
    public class LevelManager : MonoBehaviour
    {
        public int LevelNumber;

        private UIManager uiManager;

        const string Filename = "_dontTouchThis.txt";

        private void Awake()
        {
            uiManager = GetComponent<UIManager>();
        }

        private void Start()
        {
            RecordLatestLevel();
        }

        public void Update()
        {
            if (uiManager.AllowKeyInputs && uiManager.CanRestartLevel && Input.GetButton("Submit"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        public void ResetLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void Die()
        {
            uiManager.ShowDieScreen();
        }

        public void LevelComplete()
        {
            uiManager.ShowCompleteScreen();
        }

        private void RecordLatestLevel()
        {
            if (true) // LevelNumber < stord in Filename
            {
                // file.WriteLine(LevelNumber);
            }
        }

        public void LoadNextLevel()
        {
            if (LevelNumber < 5)
            {
                SceneManager.LoadScene("0" + (LevelNumber + 1));
            }
            else
            {
                SceneManager.LoadScene("Credits");
            }
        }
    }
}