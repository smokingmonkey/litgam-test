using UnityEngine;
using UnityEngine.SceneManagement;

namespace _LitgTest.Scripts.GameLogic
{
    public class SceneLoaderSingleton : MonoBehaviour
    {
        public static SceneLoaderSingleton Instance { get; private set; }
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
                return;
            }
            Instance = this;
        }

        [SerializeField] private int nextSceneIndex;
        
        public void LoadNext()
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        
        public void LoadScene(int index)
        {
            SceneManager.LoadScene(index);
        }
    }
}