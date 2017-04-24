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
        public GameObject mLight0;
        public GameObject mLight1;
        public GameObject mLight2;
        public GameObject mLight3;

        private void Start()
        {
            mMaterial = GetComponent<Renderer>().material;
            gameObject.layer = ForceFieldColors.ConvertToPhysicsLayer(FFColor);
            mPhase = 0.0f;
            mLight0.GetComponent<Light>().color = ForceFieldColors.ConvertToColor(FFColor);
            mLight1.GetComponent<Light>().color = ForceFieldColors.ConvertToColor(FFColor);
            mLight2.GetComponent<Light>().color = ForceFieldColors.ConvertToColor(FFColor);
            mLight3.GetComponent<Light>().color = ForceFieldColors.ConvertToColor(FFColor);
        }

        public void Update()
        {
            mMaterial.SetColor("_Color", ForceFieldColors.ConvertToColor(FFColor));
            mMaterial.SetFloat("_Offset", mPhase);
            mPhase += Time.deltaTime;
        }
    }
}