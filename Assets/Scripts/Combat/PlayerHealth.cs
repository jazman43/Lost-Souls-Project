using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LostSouls.Saving;



namespace LostSouls.combat
{
    public class PlayerHealth : MonoBehaviour , ISaveable
    {
        [SerializeField] private float playerMaxHealth = 100f;
        [SerializeField] private float playerDissolve;
        [SerializeField] private string playerDissolveValue;
        [SerializeField] private float maxPlayerDissolve = 0.78f;
        [SerializeField] private float PlayerDissolveSpeed = 0.08f;
        [SerializeField] private string safeZoneTag;

        [SerializeField] private float health;
        private bool isDead;

        public event Action OnDie; 
        
        [SerializeField] private Material material;

        private bool isSafe;

        private void Awake()
        {
            
        }

        private void Start()
        {
            material.SetFloat(playerDissolveValue, 0);
            health = playerMaxHealth;
            isDead = false;
        }

        private void Update()
        {
            if (!isSafe)
            {
                ChangePlayerDissolve();
            }

            CheckPlayerHealth();
            
        }

        public void DealDamage(float damageDealt)
        {
            if (!isDead)
            {
                health = Mathf.Max(health - damageDealt, 0);
            }

           
            
        }

        private void ChangePlayerDissolve()
        {
            playerDissolve = material.GetFloat(playerDissolveValue);

            if (!isDead)
            {
                playerDissolve += PlayerDissolveSpeed * Time.deltaTime;

                material.SetFloat(playerDissolveValue, playerDissolve);
            }
            

            if (playerDissolve >= maxPlayerDissolve)
            {
                //kill player
                KillPlayer();
                Debug.Log("player dead " + playerDissolve);
            }

            if(playerDissolve >= 1)
            {
                material.SetFloat(playerDissolveValue, 0);
            }
            
        }

        private void CheckPlayerHealth()
        {
            if(health <= 0.0f)
            {
                KillPlayer();
            }
        }


        private void KillPlayer()
        {
            if(health <= 0 || playerDissolve >= maxPlayerDissolve)
            {
                isDead = true;

                OnDie?.Invoke();
                //Destroy(gameObject);
            }
                
        }


        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == safeZoneTag)
            {
                material.SetFloat(playerDissolveValue, 0);
                isSafe = true;
                Debug.Log("in Safe Zone");
            }
            
        }

        private void OnTriggerExit(Collider other)
        {
            if(other.tag == safeZoneTag)
            {
                Debug.Log("out of safe zone");
                isSafe = false;
            }
        }

        public float GetPlayerHealth()
        {
            return health;
        }

        public float GetMaxPlayerHealth()
        {
            return playerMaxHealth;
        }

        public void SetPlayerHealth(float health)
        {
            this.health = health;
        }
               
        public void RestoreState(object state)
        {
            health = (float)state;


        }

        public object CaptureState()
        {
            return health;
        }
    }
}
