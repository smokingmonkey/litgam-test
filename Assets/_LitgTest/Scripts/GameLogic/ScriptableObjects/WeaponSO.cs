using _LitgTest.Scripts.GameLogic.Models.GamePlayModels;
using UnityEngine;

namespace _LitgTest.Scripts.GameLogic.ScriptableObjects
{
    [CreateAssetMenu(fileName = "newGun", menuName = "Create Gun")]
    public class WeaponSO : ScriptableObject
    {
        public new string name;
        public WeaponType weaponType;

        public float damage;

        [Tooltip("Max time attacking before reload")]
        public float cadence;

        public float reloadTime;
    }
}