using _LitgTest.Scripts.GameLogic.ScriptableObjects;
using UnityEngine;

namespace _LitgTest.Scripts.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        public WeaponSO weaponData;

        protected float cadenceCountdown;
        protected float reloadTimer;


        void Start()
        {
            cadenceCountdown = weaponData.cadence;
            reloadTimer = weaponData.reloadTime;
        }
    }
}