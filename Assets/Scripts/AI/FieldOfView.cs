using LostSouls.combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using DG.Tweening;
using UnityEngine.AI;

namespace LostSouls.AI
{

    public class FieldOfView : MonoBehaviour
    {
        public float radius;
        [Range(0, 360)]
        public float angle;

        public GameObject playerRef;

        public LayerMask targetMask;
        public LayerMask obstructionMask;

        public bool canSeePlayer;

        private Animator animator;

        //ID of material additive color parameter
        private static readonly int PROPERTY_ADDITIVE_COLOR = Shader.PropertyToID("_AdditiveColor");

        //Model Renderer
        [SerializeField] private Renderer _renderer;

        //Copy model materials
        private Material _material;

        //private Sequence _seq;
        private void Awake()
        {
            animator = GetComponent<Animator>();
            playerRef = GameObject.FindGameObjectWithTag("Player");
        }

        private void Start()
        {
            
            StartCoroutine(FOVRoutine());
        }
        private void Update()
        {
            if (canSeePlayer)
            {
                GetComponent<NavMeshAgent>().SetDestination(playerRef.transform.position);
            }

             animator.SetFloat("Blend",  GetComponent<NavMeshAgent>().velocity.magnitude);
        }

        private IEnumerator FOVRoutine()
        {
            WaitForSeconds wait = new WaitForSeconds(0.2f);
            

            while (true)
            {
                yield return wait;
                FieldOfViewCheck();
            }
        }

        private void FieldOfViewCheck()
        {
           
            Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);
            
            if (rangeChecks.Length != 0)
            {
                Debug.Log("enemy to player");
                Transform target = rangeChecks[0].transform;
                Vector3 directionToTarget = (target.position - transform.position).normalized;
                
                if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
                {
                    float distanceToTarget = Vector3.Distance(transform.position, target.position);
                    
                    if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                    {
                        canSeePlayer = true;
                        //animator.SetBool("canSeePlayer", true);
                    }
                    else
                    {
                        canSeePlayer = false;
                        //animator.SetBool("canSeePlayer", false);
                    }
                }
                else
                {
                    canSeePlayer = false;
                    //animator.SetBool("canSeePlayer", false);
                }
            }
            else if (canSeePlayer)
            {
                canSeePlayer = false;
                ///animator.SetBool("canSeePlayer", false);
            }

        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player") // check for collision with player
            {
                animator.SetTrigger("Attack");
                animator.SetInteger("AttacKIndex", Random.Range(0, 2));
                //HitFadeBlink(Color.white);
                
                Health enemyHealth = other.gameObject.GetComponent<Health>(); // get the EnemyHealth component from the current enemy

                if (enemyHealth != null)
                {
                    enemyHealth.DealDamage(5); // apply damage to the enemy
                    Debug.Log("Player Collided with enemy. damaged enemy.", enemyHealth);

                }
                else
                {
                    Debug.LogError("Player Collided with enemy. damaged enemy.", EnemyManager.CurrentEnemy);
                }

            }
        }

        /*
        
        private void Awake()
        {
            if (_renderer == null)
            {
                Debug.LogError("Renderer component is missing on the object.");
            }
            else
            {
                _renderer = GetComponent<Renderer>();
                _material = _renderer.material;  //Access material to keep auto-generated materials
            }
        }
        private void HitFadeBlink(Color color)
        {
            _seq?.Kill();
            _seq = DOTween.Sequence();
            _seq.Append(DOTween.To(() => Color.black, c => _material.SetColor(PROPERTY_ADDITIVE_COLOR, c), color, 0.1f));
            _seq.Append(DOTween.To(() => color, c => _material.SetColor(PROPERTY_ADDITIVE_COLOR, c), Color.black, 0.1f));
            _seq.Play();
        }
        */
    }
}