using System;
using _LitgTest.Scripts.Weapons;
using UnityEngine;

namespace _LitgTest.Scripts.GameLogic
{
    public class KilledEnemiesCounter : MonoBehaviour
    {
        [SerializeField] private float maxEnemies;
        [SerializeField] private float kills;

        [SerializeField] private GameObject winningGO;

        private void OnEnable()
        {
            HealthBehaviour.EnemyDied += Increase;
        }

        private void OnDisable()
        {
            HealthBehaviour.EnemyDied -= Increase;
        }

        private void Increase()
        {
            kills++;
            if (kills >= maxEnemies)
            {
                winningGO.SetActive(true);
            }
        }
    }
}