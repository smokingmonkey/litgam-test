using _LitgTest.Scripts.AI;
using UnityEngine;

namespace _LitgTest.Scripts.Weapons
{
    public class HealthBehaviour : MonoBehaviour
    {
        // public event Action<float> LifeValueChange;

        [SerializeField] private float health;
        private float maxHealth;

        // [SerializeField] private HealthBar healthBar;

        [SerializeField] private Transform healthBarTarget;

        [SerializeField] private GameObject gameOver;

        [SerializeField] bool isEnemy;

        [SerializeField] private EnemyAiBehaviour enemyAiBehaviour;

        // [SerializeField] private ExplosionController explosionControllerPrefab;

        private void Start()
        {
            maxHealth = health;
            // healthBar.target = healthBarTarget;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (isEnemy && other.CompareTag("Weapon"))
            {
                var w = other.GetComponent<Weapon>();

                ReceiveDamage(w.damage);
                return;
            }
            if (!isEnemy && other.CompareTag("EnemyWeapon"))
            {

                var w = other.GetComponent<Weapon>();

                ReceiveDamage(w.damage);
            }
        }

        public void ReceiveDamage(float damage)
        {

            if (isEnemy)
            {
                enemyAiBehaviour.CanAct = false;
            }
            
            health -= damage;

            if (health <= 0f)
            {
                if (!isEnemy)
                {
                   gameOver.SetActive(true);
                }
                else
                {
                    Destroy(gameObject);
                }

                // Instantiate(explosionControllerPrefab, transform.position, Quaternion.identity);
                // Destroy(healthBar.gameObject);
            }
            else
            {
                var normalizedLife = health / maxHealth;
                // healthBar.SetHealthBarValue(normalizedLife);

                // LifeValueChange?.Invoke(normalizedLife);
            }
        }
    }
}