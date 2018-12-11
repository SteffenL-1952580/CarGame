//======= Copyright (c) Valve Corporation, All rights reserved. ===============

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


namespace Valve.VR.InteractionSystem.Sample
{
    public class ButtonEffect : MonoBehaviour
    {
        private GameObject car;
        private Car script;

        private void Start()
        {
            ColorSelf(Color.gray);
            car = GameObject.Find("Car");
            script = car.GetComponent<Car>();
        }

        public void OnButtonDown(Hand fromHand)
        {
            script.reverseDrivingEnabled = !script.reverseDrivingEnabled;
            if (script.reverseDrivingEnabled)
            {
                ColorSelf(Color.red);
            }
            else
            {
                ColorSelf(Color.gray);
            }          
        }

        private void ColorSelf(Color newColor)
        {
            Renderer[] renderers = this.GetComponentsInChildren<Renderer>();
            for (int rendererIndex = 0; rendererIndex < renderers.Length; rendererIndex++)
            {
                renderers[rendererIndex].material.color = newColor;
            }
        }
    }
}