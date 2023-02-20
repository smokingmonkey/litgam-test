using UnityEngine;

namespace _LitgTest.Scripts.Utils
{
    public class LookAtTarget : MonoBehaviour
    {
        public Transform target;

        void Update()
        {
            transform.LookAt(target);
        }
    }
}