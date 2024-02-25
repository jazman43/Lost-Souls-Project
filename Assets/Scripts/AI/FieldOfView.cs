using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace LostSouls.AI
{

    public class FieldOfView : MonoBehaviour
    {
        public float radius;
        [Range(0, 360)]
        public float angle;

        public GameObject playerRef;

        public LayerMask targetMask;
        public LayerMask obstructionMask;

        public bool canSeePlayer;

        private void Start()
        {
            playerRef = GameObject.FindGameObjectWithTag("Player");
            StartCoroutine(FOVRoutine());
        }
        private void Update()
        {
            if (canSeePlayer)
            {
                GetComponent<NavMeshAgent>().SetDestination(playerRef.transform.position);
            }
        }

        private IEnumerator FOVRoutine()
        {
            WaitForSeconds wait = new WaitForSeconds(0.2f);

            while (true)
            {
                yield return wait;
                FieldOfViewCheck();
            }
        }
        private void FieldOfViewCheck()
        {
            Animator animator = GetComponent<Animator>();
            Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

            if (rangeChecks.Length != 0)
            {
                Transform target = rangeChecks[0].transform;
                Vector3 directionToTarget = (target.position - transform.position).normalized;

                if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
                {
                    float distanceToTarget = Vector3.Distance(transform.position, target.position);

                    if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                    {
                        canSeePlayer = true;
                        animator.SetBool("canSeePlayer", true);
                    }
                    else
                    {
                        canSeePlayer = false;
                        animator.SetBool("canSeePlayer", false);
                    }
                }
                else
                {
                    canSeePlayer = false;
                    animator.SetBool("canSeePlayer", false);
                }
            }
            else if (canSeePlayer)
            {
                canSeePlayer = false;
                animator.SetBool("canSeePlayer", false);
            }

        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("OnCollisionEnter called.");

            if (other.tag == "Player") // check for collision with player
            {
                EnemyHealth enemyHealth = EnemyManager.CurrentEnemy.GetComponent<EnemyHealth>(); // get the EnemyHealth component from the current enemy

                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(1); // apply damage to the enemy
                    Debug.Log("Player Collided with enemy. damaged enemy.", enemyHealth);

                }
                else
                {
                    Debug.LogError("Player Collided with enemy. damaged enemy.", EnemyManager.CurrentEnemy);
                }

            }
        }
    }
}