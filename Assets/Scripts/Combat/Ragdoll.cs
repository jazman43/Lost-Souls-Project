using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace LostSouls.combat
{
    public class Ragdoll : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        [SerializeField] private CharacterController controller;

        Collider[] allColliders;
        Rigidbody[] allRigidbodies;

        void Start()
        {
            allColliders = GetComponentsInChildren<Collider>(true);
            allRigidbodies = GetComponentsInChildren<Rigidbody>(true);

            ToggleRagdoll(false);
        }

        public void ToggleRagdoll(bool isRagdoll)
        {
            foreach(Collider collider in allColliders)
            {
                if (collider.gameObject.CompareTag("ragdoll"))
                {
                    collider.enabled = isRagdoll;
                }
            }

            foreach (Rigidbody rigidbody in allRigidbodies)
            {
                if (rigidbody.gameObject.CompareTag("ragdoll"))
                {
                    rigidbody.isKinematic = !isRagdoll;
                    rigidbody.useGravity = isRagdoll;
                }
            }

            controller.enabled = !isRagdoll;
            animator.enabled = !isRagdoll;
        }
    }
}

