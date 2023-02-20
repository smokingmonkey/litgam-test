using UnityEngine;

namespace _LitgTest.Scripts.Utils
{
    public class FallSensor : MonoBehaviour
    {
        [SerializeField] private GameObject restartScreen;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                restartScreen.SetActive(true);
            }
        }
    }
}