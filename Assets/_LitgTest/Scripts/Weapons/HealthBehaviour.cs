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

        // [SerializeField] private ExplosionController explosionControllerPrefab;

        private void Start()
        {
            maxHealth = health;
            // healthBar.target = healthBarTarget;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Weapon"))
            {
                var w = other.GetComponent<Weapon>();

                ReceiveDamage(w.weaponData.damage);
            }
        }

        void ReceiveDamage(float damage)
        {
            health -= damage;

            if (health <= 0f)
            {
                if (!isEnemy)
                {
                    gameOver.SetActive(true);
                }
                // Instantiate(explosionControllerPrefab, transform.position, Quaternion.identity);
                // Destroy(healthBar.gameObject);
                // Destroy(this.gameObject);
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