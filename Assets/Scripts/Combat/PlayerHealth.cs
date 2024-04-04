using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LostSouls.Saving;
using LostSouls.skill;



namespace LostSouls.combat
{
    public class PlayerHealth : MonoBehaviour , ISaveable, ISkill
    {
        
        [SerializeField] private float playerDissolve;
        [SerializeField] private string playerDissolveValue;
        [SerializeField] private float maxPlayerDissolve = 0.78f;
        [SerializeField] private float playerDissolveSpeed = 0.01f;
        [SerializeField] private string safeZoneTag;

        
        private bool isDead;


        public event Action OnDie; 
        
        [SerializeField] private Material material;

        private bool isSafe;

        public string Name => "playerDissolve";

        public bool isUnlocked { get; set; }

        private void Start()
        {
            material.SetFloat(playerDissolveValue, 0);            
            isDead = false;
        }

        private void Update()
        {
            if (!isSafe)
            {
                ChangePlayerDissolve();
            }
            
        }

        

        private void ChangePlayerDissolve()
        {
            playerDissolve = material.GetFloat(playerDissolveValue);

            if (!isDead)
            {
                playerDissolve += playerDissolveSpeed * Time.deltaTime;

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

        

        private void KillPlayer()
        {
            if(playerDissolve >= maxPlayerDissolve)
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
                
               
        public void RestoreState(object state)
        {
            playerDissolve = (float)state;
        }

        public object CaptureState()
        {
            return playerDissolve;
        }

        public void ApplySkill(GameObject player)
        {
            if (!isUnlocked) return;
            Debug.Log("skill player dissolve");
            playerDissolveSpeed = 0.01f / 4f; 
        }
    }
}
