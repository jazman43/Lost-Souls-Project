using System;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using LostSouls.Inputs;




namespace LostSouls.Interact
{
    public class Interact : MonoBehaviour
    {
        [SerializeField] float raycastRadius = 1f;
        [SerializeField] float raycastMaxDistance = 1f;
        [SerializeField] PlayerInputs inputs;

        private void Awake()
        {
            inputs = GetComponent<PlayerInputs>();
        }

        private void Update()
        {
            InteractWithComponent();
        }


        private void InteractWithComponent()
        {
            RaycastHit[] hits = RaycastAllSorted();

            foreach(RaycastHit hit in hits)
            {
                IRaycastAble[] raycastAbles = hit.transform.GetComponents<IRaycastAble>();

                foreach(IRaycastAble raycastAble in raycastAbles)
                {
                    if (raycastAble.HandleRaycast(this)) { }
                }
            }
        }

        private RaycastHit[] RaycastAllSorted()
        {
            RaycastHit[] hits = Physics.SphereCastAll(Camera.main.ScreenPointToRay(inputs.Mouse()), raycastRadius, raycastMaxDistance);
            

            float[] distances = new float[hits.Length];
            for (int i = 0; i < hits.Length; i++)
            {
                Debug.Log("dis" + i);
                distances[i] = hits[i].distance;
            }
            Array.Sort(distances, hits);
            return hits;
        }

       

    }

}