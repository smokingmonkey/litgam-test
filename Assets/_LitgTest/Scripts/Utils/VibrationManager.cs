using UnityEngine;

namespace _LitgTest.Scripts.Utils
{
    public class VibrationManager : MonoBehaviour
    {
#if !UNITY_STANDALONE
        public static void Vibrate()
        {
            Handheld.Vibrate();
        }
#endif
    }
}