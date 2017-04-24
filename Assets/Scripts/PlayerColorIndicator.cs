using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RUF
{
    public class PlayerColorIndicator : MonoBehaviour
    {
        public PlayerColor playerColor;

        private Material material;
        private Light light;

        private void Awake()
        {

            material = GetComponent<Renderer>().material;
            light = GetComponent<Light>();
        }

        private void Update()
        {
            material.color = ForceFieldColors.ConvertToColor(playerColor.FFColor);
            material.SetColor("_EmissionColor", ForceFieldColors.ConvertToColor(playerColor.FFColor));
            light.color = ForceFieldColors.ConvertToColor(playerColor.FFColor);
        }
    }
}