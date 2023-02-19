using UnityEngine;

namespace _LitgTest.Scripts.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioController : MonoBehaviour
    {
        private AudioSource audioSource;
        [SerializeField] private AudioClip clip;

        [SerializeField] private bool playOnTriggerEnter;


        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = clip;
        }

        public void PlaySound()
        {
            if (audioSource.isPlaying) return;
            audioSource.Play();
        }

        public void StopSound()
        {
            audioSource.Stop();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (playOnTriggerEnter)
            {
                if (other.CompareTag("Player") || other.CompareTag("Enemy"))
                {
                    PlaySound();
                }
            }
        }
    }
}