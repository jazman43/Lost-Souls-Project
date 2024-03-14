//using System.Collections;
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
        public static GameObject CurrentEnemy;
       
        private NavMeshAgent EnemyNavMeshAgent;

        private void Start()
        {
            CurrentEnemy = Instantiate(Enemy, EnemyPlace.position, Quaternion.identity); //first enemy when the game started

            if (CurrentEnemy != null) // check the CurrentEnemy is not null.
            {
                EnemyNavMeshAgent = CurrentEnemy.GetComponent<NavMeshAgent>(); 
            }
        }

        private void Update()
        {
            if (CurrentEnemy == null)
            {
                TimeCount += Time.deltaTime;
            }
            if (TimeCount > 3)
            {
                SoundManager.Instance.PlaySFX(SFXSoundData.SFX.Appear);
                CurrentEnemy = Instantiate(Enemy, EnemyPlace.position, Quaternion.identity); //intantiate a new enemy and reset timer
                TimeCount = 0;

                EnemyNavMeshAgent = CurrentEnemy.GetComponent<NavMeshAgent>(); //get the NavAgent from instantiated enemy

                if (EnemyNavMeshAgent != null)
                {
                    EnemyNavMeshAgent.enabled = true;
                }
            }
        }

    }
}