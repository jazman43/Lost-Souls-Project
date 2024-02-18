using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LostSouls.AI
{
    public class EnemyManager : MonoBehaviour
    {
        public GameObject Enemy; //prefab
        public Transform EnemyPlace;

        public float TimeCount;

        private GameObject CurrentEnemy; //reference of Enemy

        private void Update()
        {
            if (CurrentEnemy == null)
            {
                TimeCount += Time.deltaTime;
            }
            if (TimeCount > 3)
            {
                CurrentEnemy = Instantiate(Enemy, EnemyPlace.position, Quaternion.identity);
                TimeCount = 0;
            }
        }


        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player" && CurrentEnemy != null)
            {
                Destroy(CurrentEnemy);

            }
        }
    }
}