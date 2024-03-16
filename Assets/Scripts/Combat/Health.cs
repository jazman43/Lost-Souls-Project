using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace LostSouls.combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float MaxHealth = 100f;
        

        private float health;
        private bool isDead;

        


        private void Start()
        {           
            health = MaxHealth;
            isDead = false;
        }

        private void Update()
        {
           
            CheckHealth();
            
        }

        public void DealDamage(float damageDealt)
        {
            if (!isDead)
            {
                health = Mathf.Max(health - damageDealt, 0);
            }

            Debug.Log(health);
        }

       

        private void CheckHealth()
        {
            if (health <= 0.0f)
            {
                Kill();
            }
        }


        private void Kill()
        {
            if (health <= 0)
            {
                isDead = true;
                Destroy(gameObject);
            }

        }      

       

        public object CapturState()
        {
            return health;
        }

        public void RestoreState(object state)
        {
            health = (float)state;


        }
    }
}


