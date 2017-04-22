using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RUF
{
    public class ForceField : MonoBehaviour
    {
        public ForceFieldColors.Values FFColor;
        private float mPhase;
        private Material mMaterial;

        private void Start()
        {
            mMaterial = GetComponent<Renderer>().material;
            gameObject.layer = ForceFieldColors.ConvertToPhysicsLayer(FFColor);
            mPhase = 0.0f;
        }

        public void Update()
        {
            mMaterial.SetColor("_Color", ForceFieldColors.ConvertToColor(FFColor));
            mMaterial.SetFloat("_Offset", mPhase);
            mPhase += Time.deltaTime;
        }
    }
}