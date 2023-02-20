using _LitgTest.Scripts.Audio;
using UnityEngine;

namespace _LitgTest.Scripts.Weapons
{
    public class EarthquakeBehaviour : Weapon
    {
        [SerializeField] private float acceleration;
        [SerializeField] GameObject referenceSphere;
        [SerializeField] GameObject blur;

        private float reloadingTimer;
        private bool CanAttack => reloadingTimer >= weaponData.reloadTime;

        private float sphereRadius;

        [SerializeField] private LayerMask layerMask;

        [SerializeField] private AudioController audioController;

        void Start()
        {
            reloadingTimer = weaponData.reloadTime;

            sphereRadius = referenceSphere.transform.lossyScale.x / 2f;

            GetComponent<SphereCollider>().radius = sphereRadius;
        }

        //Note: the Attack() method inside this Update is called only 1 time every x seconds, so the expensive calling warning can be ignored.
        private void Update()
        {
            if (CanAttack)
            {
                referenceSphere.SetActive(false);
                blur.SetActive(true);
                audioController.StopSound();

                if (Input.GetMouseButtonDown(0))
                {
                    Attack();
                    reloadingTimer = 0f;
                    return;
                }
            }

            reloadingTimer += Time.deltaTime;
        }

        void Attack()
        {
            referenceSphere.SetActive(true);
            blur.SetActive(false);

            audioController.PlaySound();

            int maxColliders = 50;
            Collider[] results = new Collider[maxColliders];

            var size = Physics.OverlapSphereNonAlloc(referenceSphere.transform.position, sphereRadius, results,
                layerMask);

            for (int i = 0; i < size; i++)
            {
                if (results[i].CompareTag("Enemy") || results[i].CompareTag("Item"))
                {
                    ApplyForce(results[i].GetComponent<Rigidbody>());
                    ApplyDamage(results[i].GetComponent<HealthBehaviour>());
                }

                if (results[i].CompareTag("Floor"))
                {
                    results[i].GetComponent<FloorEarthquakeBehaviour>().SetEarthquakeMaterial();
                }
            }
        }

        

        void ApplyForce(Rigidbody body)
        {
            if (!body)
            {
                return;
            }

            body.AddForce(Vector3.up * acceleration, ForceMode.Impulse);
        }

        void ApplyDamage(HealthBehaviour healthBehaviour)
        {
            if (!healthBehaviour)
            {
                return;
            }

            healthBehaviour.ReceiveDamage(damage);
        }
    }
}