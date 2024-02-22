using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace LostSouls.AI
{
    public class EnemyManager : MonoBehaviour
    {
        public GameObject Enemy; //prefab
        public Transform EnemyPlace;

        public float TimeCount;

        private GameObject CurrentEnemy; //reference of Enemy
        private NavMeshAgent EnemyNavMeshAgent;

        private void Update()
        {
            if (CurrentEnemy == null)
            {
                TimeCount += Time.deltaTime;
            }
            if (TimeCount > 3)
            {
                CurrentEnemy = Instantiate(Enemy, EnemyPlace.position, Quaternion.identity); //intantiate a new enemy and reset timer
                TimeCount = 0;

                EnemyNavMeshAgent = CurrentEnemy.GetComponent<NavMeshAgent>(); //get the NavAgent from instantiated enemy

                if (EnemyNavMeshAgent != null)
                {
                    EnemyNavMeshAgent.enabled = true;
                }
            }
        }


        void OnCollisionEnter(Collision collision)
        {
            Debug.Log("OnCollisionEnter called."); // この行を追加

            if (collision.collider.CompareTag("Player") && CurrentEnemy != null) // check for collision with player
            {
                EnemyHealth enemyHealth = CurrentEnemy.GetComponent<EnemyHealth>(); // get the EnemyHealth component from the current enemy

                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(1); // apply damage to the enemy
                    Debug.Log("Player Collided with enemy. damaged enemy.", enemyHealth);

                } else {
                    Debug.LogError("Player Collided with enemy. damaged enemy.", CurrentEnemy);
                }

            }
        }
    }
}