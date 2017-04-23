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

        private void Awake()
        {
            uiManager = GetComponent<UIManager>();
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
            Debug.Log("Complete!!");
        }
    }
}