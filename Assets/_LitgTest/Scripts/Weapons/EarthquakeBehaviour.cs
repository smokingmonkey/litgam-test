using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace _LitgTest.Scripts.Weapons
{
    public class EarthquakeBehaviour : Weapon
    {
        [SerializeField] private float acceleration;
        [SerializeField] GameObject referenceSphere;
        private float reloadingTimer;
        private bool CanAttack => reloadingTimer >= weaponData.reloadTime;

        private float sphereRadius;

        [SerializeField] private LayerMask layerMask;

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

            Debug.Log("attac");
            int maxColliders = 10;
            Collider[] results = new Collider[maxColliders];

            var size = Physics.OverlapSphereNonAlloc(referenceSphere.transform.position, sphereRadius, results,
                layerMask);

            for (int i = 0; i < size; i++)
            {
                if (results[i].CompareTag("Enemy") || results[i].CompareTag("Item"))
                {
                    ApplyForce(results[i].GetComponent<Rigidbody>());
                }
            }
        }


        void ApplyForce(Rigidbody body)
        {
            body.AddForce(Vector3.up * acceleration, ForceMode.Impulse);
        }
    }
}