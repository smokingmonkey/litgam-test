using System;
using UnityEngine;
using UnityEngine.Serialization;

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

        [FormerlySerializedAs("rigidbody")] [SerializeField]private Rigidbody bulletRigidbody;

        private void OnEnable()
        {
            currentLifeTime = 0;
            isAvailable = false;
            if (bulletRigidbody) bulletRigidbody.velocity = transform.forward * speed;
        }

        private void Start()
        {
            bulletRigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
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
            if (bulletRigidbody) bulletRigidbody.velocity = Vector3.zero;

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