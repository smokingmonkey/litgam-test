using System;
using _LitgTest.Scripts.GameLogic;
using _LitgTest.Scripts.Helpers;
using UnityEngine;

namespace _LitgTest.Scripts.GUI
{
    public class LoadSceneByAction : GenericActionButton
    {
        [SerializeField] private int sceneIndex;
        private void OnEnable()
        {
            PointerDown += () => SceneLoaderSingleton.Instance.LoadScene(sceneIndex);
        }

        private void Update()
        {
            if (Input.anyKey)
            {
                SceneLoaderSingleton.Instance.LoadScene(sceneIndex);
            }
        }
    }
}