using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RUF
{
    public class PlayerColorIndicator : MonoBehaviour
    {
        public PlayerColor playerColor;

        private Material material;

        private void Awake()
        {
            material = GetComponent<Renderer>().material;
        }

        private void Update()
        {
            material.color = ForceFieldColors.ConvertToColor(playerColor.FFColor);
        }
    }
}