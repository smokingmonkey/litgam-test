using System.Collections.Generic;
using _LitgTest.Scripts.Audio;
using _LitgTest.Scripts.Weapons;
using UnityEngine;

namespace _Andy.Scripts.Weapons
{
    public class BulletSpawner : MonoBehaviour
    {
        [SerializeField] private Transform spawnPositionReference;
        [SerializeField] private Transform spawnDirectionReference;

        [SerializeField] private GameObject bulletPrefab;

        [SerializeField] private int startingAmount;

        private Queue<BulletBehaviour> bullets;

        [SerializeField] private List<BulletBehaviour> bulletsList;

        [SerializeField] public AudioController audioController;

        private void OnDisable()
        {
            foreach (var bulletBehaviour in bulletsList)
            {
                bulletBehaviour.HaveDie -= EnqueueBullet;
            }
        }

        void EnqueueBullet(BulletBehaviour bulletBehaviour)
        {
            bullets.Enqueue(bulletBehaviour);
        }

        public void SpawnBullet()
        {
            if (bullets.Count > 0)
            {
                var bullet = bullets.Dequeue();
                bullet.transform.position = spawnPositionReference.position;
                bullet.transform.forward = spawnDirectionReference.forward;
                bullet.gameObject.SetActive(true);
                audioController.PlaySound();
            }
        }


        public void Init(BulletBehaviour bulletBehaviour)
        {
            bulletPrefab = bulletBehaviour.gameObject;

            bullets = new Queue<BulletBehaviour>();
            bulletsList = new List<BulletBehaviour>();

            for (int i = 0; i < startingAmount; i++)
            {
                var bullet = Instantiate(bulletPrefab).GetComponent<BulletBehaviour>();

                bullets.Enqueue(bullet);
                bulletsList.Add(bullet);
                bullet.HaveDie += EnqueueBullet;
            }
        }
    }
}