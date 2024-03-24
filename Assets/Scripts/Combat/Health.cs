using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LostSouls.Saving;
using LostSouls.skill;


namespace LostSouls.combat
{
    public class Health : MonoBehaviour, ISaveable, ISkill
    {
        [SerializeField] private float MaxHealth = 100f;
        

        private float health;
        private bool isDead;

        public string Name => "Incresses Health";

        public bool isUnlocked { get ; set; }

        public event Action OnDie;


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
                isDead = true;

                OnDie?.Invoke();
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

        public float GetPlayerHealth()
        {
            return health;
        }

        public float GetMaxPlayerHealth()
        {
            return MaxHealth;
        }

        public object CaptureState()
        {
            return health;
        }

        public void RestoreState(object state)
        {
            health = (float)state;

        }

        public void ApplySkill(GameObject player)
        {
            if (!isUnlocked) return;
            Debug.Log("unlocked new health");
            MaxHealth += 100;
            health += 100;
        }
    }
}


