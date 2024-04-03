using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace LostSouls.Interact.UI
{
    public class InteratUIPopup : MonoBehaviour
    {
        [SerializeField] GameObject interactableTextPrefab = null;

        public void SpawnInteractableText()
        {


            GameObject instance = Instantiate<GameObject>(interactableTextPrefab, transform);

            Destroy(instance, 0.1f);
        }
    }
}

