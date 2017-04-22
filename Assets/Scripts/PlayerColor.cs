using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RUF
{
    public class PlayerColor : MonoBehaviour
    {
        public ForceFieldColors.Values FFColor;

        private void Update()
        {
            gameObject.layer = ForceFieldColors.ConvertToPlayerPhysicsLayer(FFColor);
        }        
    }
}