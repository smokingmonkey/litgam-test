using System;
using _Andy.Scripts.Weapons;
using _LitgTest.Scripts.Weapons;
using UnityEngine;


namespace _LitgTest.Scripts.GameLogic.Models.GamePlayModels
{
    [RequireComponent(typeof(BulletSpawner))]
    public class MachineGun : Weapon
    {
        [SerializeField] private BulletSpawner charger;
        [SerializeField] private BulletBehaviour bulletPrefab;


        void Start()
        {
            bulletPrefab.Init(weaponData.damage);

            charger = GetComponent<BulletSpawner>();
            charger.Init(bulletPrefab);
        }


        private void Update()
        {
            if (Input.GetMouseButton(0) )
            {
                Attack();
            }
        }

        void Attack()
        {
            charger.SpawnBullet();
        }
    }
}