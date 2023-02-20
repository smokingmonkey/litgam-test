using _LitgTest.Scripts.Audio;
using UnityEngine;

namespace _LitgTest.Scripts.VFX
{
    [RequireComponent(typeof(AudioController))]
    public class ExplosionController : MonoBehaviour
    {
        private AudioController audioController;
        void Start()
        {
            audioController = GetComponent<AudioController>();
            audioController.PlaySound();
            Destroy(gameObject, 5f);
        }
    }
}