using System;
using _Andy.Scripts.Weapons;
using _LitgTest.Scripts.Weapons;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace _LitgTest.Scripts.AI
{
    public class EnemyShootingBehaviour : Weapon
    {
        private bool canShoot;


        private BulletSpawner charger;
        [SerializeField] private BulletBehaviour bulletPrefab;


        private void Start()
        {
            bulletPrefab.Init(weaponData);

            charger = GetComponent<BulletSpawner>();
            charger.Init(bulletPrefab);
        }

        public void EnableShoot()
        {
            canShoot = true;
        }

        public void DisableShoot()
        {
            canShoot = false;
        }

        private void Update()
        {
            if (canShoot)
            {
                Shoot();
            }
        }


        void Shoot()
        {
            charger.SpawnBullet();
        }
    }
}