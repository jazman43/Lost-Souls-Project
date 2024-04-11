using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.VFX;


namespace LostSouls.Cam
{
    public class CinematicCharacterMover : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent meshAgent;
        [SerializeField] private Animator animator;
        [SerializeField] private Transform cinemaMoveTo;
        [SerializeField] private VisualEffect visualEffect;


        private void Start()
        {
            meshAgent.SetDestination(cinemaMoveTo.position);

            visualEffect.Stop();
        }

        private void Update()
        {
            animator.SetFloat("Move", meshAgent.velocity.magnitude);
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other);
            if (other.tag == "Portal")
            {
                visualEffect.Play();
                Debug.Log("Portal");
                Destroy(gameObject, 2f);
            }
        }
    }
}
