using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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