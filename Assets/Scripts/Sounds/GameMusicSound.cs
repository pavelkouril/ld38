using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RUF
{
    public class GameMusicSound : MonoBehaviour
    {
        private static GameMusicSound instance = null;

        public static GameMusicSound Instance
        {
            get { return instance; }
        }

        void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
                return;
            }
            else
            {
                instance = this;
            }
            DontDestroyOnLoad(gameObject);
        }
    }
}