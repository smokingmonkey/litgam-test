using _LitgTest.Scripts.GameLogic;
using _LitgTest.Scripts.Helpers;
using UnityEngine;

namespace _LitgTest.Scripts.GUI
{
    public class LoadSceneByAction : GenericActionButton
    {
        [SerializeField] private int sceneIndex;

        protected override void OnEnable()
        {
            PointerDown += LoadByClick;
        }
        
        protected override void OnDisable()
        {
            PointerDown -= LoadByClick;
        }
        
        private void Update()
        {
            if (Input.anyKey)
            {
                SceneLoaderSingleton.Instance.LoadNext();
            }
        }

        private void LoadByClick()
        {
            SceneLoaderSingleton.Instance.LoadNext();
        }

       
    }
}
