using UnityEngine;

namespace _LitgTest.Scripts.Utils
{
    public class LookAtPlayer : LookAtTarget
    {
        void Start()
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
}