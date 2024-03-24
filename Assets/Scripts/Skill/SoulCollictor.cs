using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace LostSouls.skill
{
    public class SoulCollictor : MonoBehaviour
    {
        [SerializeField]private int currentPonits = 0;
        [SerializeField] private string soulsTagName = "soul";


        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == soulsTagName)
            {
                currentPonits += 1;
            }
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

