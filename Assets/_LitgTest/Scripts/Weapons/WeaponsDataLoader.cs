using System.Collections.Generic;
using _LitgTest.Scripts.GameLogic.Models.GamePlayModels;
using _LitgTest.Scripts.GameLogic.ScriptableObjects;
using UnityEngine;
using UnityEngine.Serialization;

namespace _LitgTest.Scripts.Weapons
{
    public class WeaponsDataLoader : MonoBehaviour
    {
        [SerializeField] private Weapon machineGun;
        [SerializeField] private List<Weapon> enemiesMachineGun;
        [SerializeField] private Weapon earthQuake;
        [SerializeField] private Weapon field;

        void Start()
        {
            WeaponSO[] weaponsData = Resources.LoadAll<WeaponSO>("ScriptableObjects/");
            foreach (var weapon in weaponsData)
            {
                if (weapon.weaponType.Equals(WeaponType.Bullets))
                {
                    machineGun.SetWeaponData(weapon);
                }

                if (weapon.weaponType.Equals(WeaponType.EnemyBullets))
                {
                    foreach (var enemy in enemiesMachineGun)
                    {
                        enemy.SetWeaponData(weapon);
                    }
                }

                if (weapon.weaponType.Equals(WeaponType.ForceField))
                {
                    field.SetWeaponData(weapon);
                }

                if (weapon.weaponType.Equals(WeaponType.DirectContact))
                {
                    earthQuake.SetWeaponData(weapon);
                }
            }
        }
    }
}