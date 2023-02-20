using _LitgTest.Scripts.GameLogic.ScriptableObjects;
using UnityEngine;

namespace _LitgTest.Scripts.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        public WeaponSO weaponData;

        public float cadenceCountdown;
        public float reloadTimer;
        public float damage;

       public void SetWeaponData(WeaponSO data)
        {
            weaponData = data;

            cadenceCountdown = data.cadence;
            reloadTimer = data.reloadTime;
            damage = data.damage;
        }
    }
}