using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RUF
{
    public class GameMusicSound : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}