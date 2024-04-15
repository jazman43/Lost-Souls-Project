using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace LostSouls.skill
{
    public class SoulSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject soulPreFab;
        [SerializeField] private float spawnRadius = 30f;
        [SerializeField] private int numberOfSouls = 5;
        private List<GameObject> spawnedSouls = new List<GameObject>();
        
        

        private void Update()
        {
            RemoveSoul();
            AddNewSoul();
        }

        private void RemoveSoul()
        {
            for(int i = spawnedSouls.Count -1; i >=0; i--)
            {
                if(Vector3.Distance(transform.position, spawnedSouls[i].transform.position) > spawnRadius)
                {
                    Debug.Log("remove Soul");
                    Destroy(spawnedSouls[i]);
                    spawnedSouls.RemoveAt(i);
                }
            }
        }

        private void AddNewSoul()
        {
            int soulsToSpawn = numberOfSouls - spawnedSouls.Count;

            for(int i = 0; i < soulsToSpawn; i++)
            {
                SpawnSoul();
            }
        }

        private void SpawnSoul()
        {
            Vector2 spawnCircle = Random.insideUnitCircle * spawnRadius;
            Vector3 randomPosition = transform.position + new Vector3(spawnCircle.x
            , transform.position.y
            , spawnCircle.y
            );

            randomPosition.y = transform.position.y + 0.75f;
            //Debug.Log("add Soul" + randomPosition + " " + transform.position);
            GameObject spawnedSoul = Instantiate(soulPreFab, randomPosition, Quaternion.identity);
            spawnedSouls.Add(spawnedSoul);
        }

        public void RemoveSoulFromList(GameObject soul)
        {
            if (spawnedSouls.Contains(soul))
            {
                spawnedSouls.Remove(soul);
            }
        }
    }
}

