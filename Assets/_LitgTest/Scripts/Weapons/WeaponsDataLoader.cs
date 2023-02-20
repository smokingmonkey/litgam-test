using System.Collections.Generic;
using _LitgTest.Scripts.GameLogic.Models.GamePlayModels;
using _LitgTest.Scripts.GameLogic.ScriptableObjects;
using UnityEngine;

namespace _LitgTest.Scripts.Weapons
{
    public class WeaponsDataLoader : MonoBehaviour
    {
        [SerializeField] private Weapon machineGun;
        [SerializeField] private Weapon enemyMachineGun;
        [SerializeField] private Weapon earthQuake;
        [SerializeField] private Weapon field;

        void Start()
        {
            WeaponSO[] weaponsData = Resources.LoadAll<WeaponSO>("ScriptableObjects/");
            foreach (var weapon in weaponsData)
            {
                if (weapon.weaponType.Equals(WeaponType.Bullets))
                {
                    machineGun.weaponData = weapon;
                }

                if (weapon.weaponType.Equals(WeaponType.EnemyBullets))
                {
                    enemyMachineGun.weaponData = weapon;
                }

                if (weapon.weaponType.Equals(WeaponType.ForceField))
                {
                    field.weaponData = weapon;
                }

                if (weapon.weaponType.Equals(WeaponType.DirectContact))
                {
                    earthQuake.weaponData = weapon;
                }
            }
        }
    }
}