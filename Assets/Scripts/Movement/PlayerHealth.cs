using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace LostSouls.Movement
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private float playerHealth = 100f;
        [SerializeField] private float playerDissolve;
        [SerializeField] private string playerDissolveValue;
        [SerializeField] private float maxPlayerDissolve = 0.78f;
        [SerializeField] private float PlayerDissolveSpeed = 0.08f;
        [SerializeField] private string safeZoneTag;

        
        [SerializeField] private Material material;

        private bool isSafe;

        private void Awake()
        {
            
        }

        private void Start()
        {
            material.SetFloat(playerDissolveValue, 0);
        }

        private void Update()
        {
            if (!isSafe)
            {
                ChangePlayerDissolve();
            }

            CheckPlayerHealth();
            Debug.Log(playerDissolve);
        }


        private void ChangePlayerDissolve()
        {
            playerDissolve = material.GetFloat(playerDissolveValue);
            playerDissolve += PlayerDissolveSpeed * Time.deltaTime;

            material.SetFloat(playerDissolveValue, playerDissolve);

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
            if(playerHealth <= 0.0f)
            {
                KillPlayer();
            }
        }


        private void KillPlayer()
        {
            Destroy(gameObject);
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
    }
}
