using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RUF
{
    public class ForceField : MonoBehaviour
    {
        public ForceFieldColors.Values FFColor;

        private void Start()
        {
            GetComponent<Renderer>().material.color = ForceFieldColors.ConvertToColor(FFColor);
            gameObject.layer = ForceFieldColors.ConvertToPhysicsLayer(FFColor);
        }
    }
}