using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace LostSouls.skill
{
    public class SoulCollictor : MonoBehaviour
    {
        [SerializeField]private int currentPonits = 0;
        [SerializeField] private string soulsTagName = "Soul";
        private SoulSpawner soulSpawner;

        private void Awake()
        {
            soulSpawner = FindObjectOfType<SoulSpawner>();
        }

        private void OnTriggerEnter(Collider other)
        {
            //Debug.Log(other.tag + "hit soul");
            if (other.tag == soulsTagName)
            {
                currentPonits += 1;
                soulSpawner.RemoveSoulFromList(other.gameObject);
                Destroy(other.gameObject);
            }
        }

        private void Update()
        {
            
            Debug.Log(currentPonits);
        }

        public int GetPonits()
        {
            return currentPonits;
        }

        public void SetPonits(int ponits)
        {
            this.currentPonits = ponits;
        }
    }
}

