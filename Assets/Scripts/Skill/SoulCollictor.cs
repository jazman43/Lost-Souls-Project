using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LostSouls.Saving;


namespace LostSouls.skill
{
    public class SoulCollictor : MonoBehaviour , ISaveable
    {
        [SerializeField]private float currentPonits = 0;
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
           
        }

        public float GetPonits()
        {
            return currentPonits;
        }

        public object CaptureState()
        {
            //Debug.Log(currentPonits + "points Saved");
            return currentPonits;
        }

        public void SetPonits(float ponits)
        {
            this.currentPonits = ponits;
        }

        

        public void RestoreState(object state)
        {
            currentPonits = (float)state;
        }
    }
}

