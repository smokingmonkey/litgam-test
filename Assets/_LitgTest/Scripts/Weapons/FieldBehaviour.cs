using System;
using System.Collections.Generic;
using _LitgTest.Scripts.Audio;
using UnityEngine;

namespace _LitgTest.Scripts.Weapons
{
    public class FieldBehaviour : Weapon
    {
        [SerializeField] private float speed;

        [SerializeField] float lifeTime;
        private float currentLifeTime;

        [SerializeField] private float damage;

        [SerializeField] private float maxDistance;

        [SerializeField] private Transform parent;

        private List<Rigidbody> bodies;

        [SerializeField] float acceleration;

        private Vector3 startPos;

        [SerializeField] private AudioController audioController;

        private void OnEnable()
        {
            currentLifeTime = 0;
        }

        private void Start()
        {
            bodies = new List<Rigidbody>();
            startPos = transform.localPosition;

            Init(weaponData.damage);
            
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Q))
            {
                if (transform.localPosition.z > parent.localPosition.z)
                {
                    transform.Translate(0f, 0f, -speed * Time.deltaTime);
                }
            }
            else if (Input.GetKey(KeyCode.E))
            {
                if (transform.localPosition.z < parent.localPosition.z + maxDistance)
                {
                    transform.Translate(0f, 0f, speed * Time.deltaTime);
                }
            }
        }

        private void FixedUpdate()
        {
            if (currentLifeTime >= lifeTime)
            {
                currentLifeTime = 0f;
                ClearField();
                return;
            }

            currentLifeTime += Time.deltaTime;
            
            audioController.PlaySound();

            foreach (var item in bodies)
            {
                Attract(item);
            }
        }


        public void Init(float weaponDataDamage)
        {
            damage = weaponDataDamage;
            audioController = GetComponent<AudioController>();
        }

        void ClearField()
        {
            transform.localPosition = startPos;
            audioController.StopSound();
            if (bodies.Count == 0)
            {
                return;
            }

            bodies = new List<Rigidbody>();
        }

        void CaptureItem(Collider item)
        {
            bodies.Add(item.GetComponent<Rigidbody>());
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy") || other.CompareTag("Item"))
            {
                CaptureItem(other);
            }
        }


        public void Attract(Rigidbody body)
        {
            var bodyTransform = body.transform;

            Vector3 gravityUp = (bodyTransform.position - transform.position).normalized;

            body.AddForce(gravityUp * acceleration);
        }
    }
}