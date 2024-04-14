using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LostSouls.SoundManager;

namespace LostSouls.AI
{

    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private int enemyHealth = 10; //Enemies max health
        [SerializeField] private float enemyDissolve;
        [SerializeField] private string enemyDissolveValue;
        //[SerializeField] private float maxEnemyDissolve = 0.78f;
        [SerializeField] private float enemyDissolveSpeed = 0.01f;
        [SerializeField] private Material material;
        private void Start()
        {
            material.SetFloat(enemyDissolveValue, 0);

        }
  
        public void TakeDamage(int damageAmount)
        {
            SFXManager.Instance.PlaySFX(SFXSoundData.SFX.Damage);
            enemyHealth -= damageAmount;
            enemyDissolve += enemyDissolveSpeed * Time.deltaTime;
            material.SetFloat(enemyDissolveValue, enemyDissolve);
            Debug.Log(gameObject.name + " took damage. Current health: " + enemyHealth);

            if(enemyHealth <= 0)
            {
                material.SetFloat(enemyDissolveValue, 0);
                Debug.Log(gameObject.name + " has been destroyed.");
                Destroy(gameObject, 1f);　// destroy after 1 sec
            }
        }
    }

}
