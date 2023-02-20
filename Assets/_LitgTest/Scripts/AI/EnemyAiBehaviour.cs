using UnityEngine;
using UnityEngine.AI;

namespace _LitgTest.Scripts.AI
{
    public class EnemyAiBehaviour : MonoBehaviour
    {
        public NavMeshAgent agent;

        private Transform player;


        [SerializeField] private LayerMask isGround, isPlayer;

        [SerializeField] EnemyShootingBehaviour attackComponent;

        //For patrolling
        Vector3 walkPoint;
        private bool walkPointSet;
        [SerializeField] public float walkPointRange;

        //Attacking
        [SerializeField] private float timeBetweenAttacks;
        private bool alreadyAttacked;

        //States
        [SerializeField] float sightRange, attackRange;
        [SerializeField] bool playerIsInSightRange, playerIsInAttackRange;


        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            player = GameObject.FindGameObjectWithTag("Player").transform;

        }

        private void Update()
        {
            playerIsInSightRange = Physics.CheckSphere(transform.position, sightRange, isPlayer);
            playerIsInAttackRange = Physics.CheckSphere(transform.position, attackRange, isPlayer);

            if (!playerIsInSightRange && !playerIsInAttackRange)
            {
                Patrolling();
            }

            if (playerIsInSightRange && !playerIsInAttackRange)
            {
                ChasePlayer();
            }

            if (playerIsInSightRange && playerIsInAttackRange)
            {
                AttackPlayer();
            }

            if (!playerIsInAttackRange)
            {
                attackComponent.DisableShoot();
            }
        }

        void Patrolling()
        {
            if (!walkPointSet)
            {
                SetWalkPoint();
            }

            agent.SetDestination(walkPoint);

            Vector3 distanceToWalkPoint = transform.position - walkPoint;

            if (distanceToWalkPoint.magnitude < 1f) walkPointSet = false;
        }

        private void SetWalkPoint()
        {
            float randomZ = Random.Range(-walkPointRange, walkPointRange);
            float randomX = Random.Range(-walkPointRange, walkPointRange);

            walkPoint = new Vector3(transform.position.x + randomX, transform.position.y,
                transform.position.z + randomZ);

            if (Physics.Raycast(walkPoint, -transform.up, 2f, isGround))
            {
                walkPointSet = true;
            }
        }


        void ChasePlayer()
        {
            agent.SetDestination(player.position);
        }

        void AttackPlayer()
        {
            agent.SetDestination(transform.position);
            transform.LookAt(player);
            attackComponent.EnableShoot();

            if (!alreadyAttacked)
            {
                alreadyAttacked = true;
                Invoke(nameof(ResetAttack), timeBetweenAttacks);
            }
        }

        void ResetAttack()
        {
            alreadyAttacked = false;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackRange);
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, sightRange);
        }
    }
}