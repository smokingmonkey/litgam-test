using System;
using UnityEngine;

namespace _LitgTest.Scripts.Weapons
{
    [RequireComponent(typeof(Rigidbody))]
    public class BulletBehaviour : MonoBehaviour
    {
        public event Action<BulletBehaviour> HaveDie;

        [SerializeField] private float speed;

        [SerializeField] float lifeTime;
        private float currentLifeTime;

        [SerializeField] private float damage;

        public bool isAvailable;

        [SerializeField]private Rigidbody rigidbody;

        private void OnEnable()
        {
            currentLifeTime = 0;
            isAvailable = false;
            if (rigidbody) rigidbody.velocity = transform.forward * speed;
        }

        private void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (currentLifeTime >= lifeTime)
            {
                ReturnBulletToPool();
                currentLifeTime = 0f;
                return;
            }

            currentLifeTime += Time.deltaTime;
        }


        private void OnTriggerEnter(Collider other)
        {
            ReturnBulletToPool();
        }

        void ReturnBulletToPool()
        {
            if (rigidbody) rigidbody.velocity = Vector3.zero;

            gameObject.SetActive(false);
            isAvailable = true;
            HaveDie?.Invoke(this);
        }

        public void Init(float weaponDataDamage)
        {
            damage = weaponDataDamage;
        }
    }
}