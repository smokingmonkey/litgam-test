using UnityEngine;

namespace _LitgTest.Scripts.Utils
{
    public class SinusoidalMovement : MonoBehaviour
    {
        [SerializeField] private float xAmplitude;
        [SerializeField] private float yAmplitude;
        [SerializeField] private float zAmplitude;

        [SerializeField] private float speed;

        private Vector3 startPos;

        private void Start()
        {
            startPos = transform.position;
        }

        void Update()
        {
            transform.position = startPos + new Vector3(xAmplitude, yAmplitude, zAmplitude) * Mathf.Sin(speed * Time.time);
        }
    }
}