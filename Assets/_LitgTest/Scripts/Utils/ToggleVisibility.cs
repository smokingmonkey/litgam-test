using System;
using UnityEngine;

namespace _LitgTest.Scripts.Utils
{
    public class ToggleVisibility : MonoBehaviour
    {
        public GameObject go;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                go.SetActive(!go.activeSelf);
                Time.timeScale = Math.Abs(Time.timeScale - 1f) < 0.1f ? 0f : 1f;
            }
        }
    }
}
