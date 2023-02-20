using _LitgTest.Scripts.GameLogic;
using _LitgTest.Scripts.Helpers;
using UnityEngine;

namespace _LitgTest.Scripts.GUI
{
    public class LoadSceneByAction : GenericActionButton
    {
        [SerializeField] private int sceneIndex;

        private bool isLoading;

        private float loadingTime = 3f;

        private float subscribeDelay = 5f;

        protected override void Start()
        {
            Invoke(nameof(Subscribe), subscribeDelay);
        }

        protected override void OnDisable()
        {
            PointerDown -= LoadByClick;
        }

        private void Update()
        {
            if (Input.anyKey && !isLoading)
            {
                isLoading = true;
                Invoke(nameof(Load), loadingTime);
            }
        }

        private void LoadByClick()
        {
            if (!isLoading)
            {
                isLoading = true;
                Invoke(nameof(Load), loadingTime);
            }
        }

        void Subscribe()
        {
            PointerDown += LoadByClick;
        }

        void Load()
        {
            SceneLoaderSingleton.Instance.LoadNext();
        }
    }
}