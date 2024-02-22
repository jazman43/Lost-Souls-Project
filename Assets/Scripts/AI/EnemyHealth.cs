using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LostSouls.AI {

    public class EnemyHealth : MonoBehaviour
    {
        public int enemyHealth = 10; //Enemies max health

        public void TakeDamage(int damageAmount)
        {
            enemyHealth -= damageAmount;
            Debug.Log(gameObject.name + " took damage. Current health: " + enemyHealth);

            if(enemyHealth <= 0)
            {
                Debug.Log(gameObject.name + " has been destroyed.");
                Destroy(gameObject);　
            }
        }
    }

}
