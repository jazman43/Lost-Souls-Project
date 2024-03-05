using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LostSouls.Inputs;
using System;

namespace LostSouls.Movement
{
    public class Slider : MonoBehaviour
    {
        [Header("Refe")]
        [SerializeField] private Transform playerObj;
        private Rigidbody rigidbody;
        private PlayerMovement movement;
        private PlayerInputs inputs;

        [Header("Sliding")]
        [SerializeField] private float maxSlideTime;
        [SerializeField] private float slideForce;
        private float slideTimer;
        private bool sliding;


        [SerializeField] float slideYScale;
        private float startYScale;


        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
            movement = GetComponent<PlayerMovement>();
            inputs = GetComponent<PlayerInputs>();
            
        }

        private void Start()
        {
            startYScale = playerObj.localScale.y;

        }

        private void Update()
        {
            /*
            if(inputs.Slide() && (inputs.Movement().x != 0 || inputs.Movement().y != 0))
            {
                StartSlide();
            }

            if (!inputs.Slide() && movement.sliding)
            {
                StopSliding();
            }
            */
        }

        private void FixedUpdate()
        {
            if (movement.sliding)
                SlidingMovement();
        }

        private void StopSliding()
        {
            movement.sliding = false;

            playerObj.localScale = new Vector3(playerObj.localScale.x, startYScale, playerObj.localScale.z);
        }

        private void StartSlide()
        {
            movement.sliding = true;
            Debug.Log("Slide"); 
            playerObj.localScale = new Vector3(playerObj.localScale.x, slideYScale, playerObj.localScale.z);
            while (!movement.IsPlayerGrounded())
            {
                rigidbody.AddForce(Vector3.down * 5f, ForceMode.Impulse);
            }

            slideTimer = maxSlideTime;
        }

        private void SlidingMovement()
        {
            Vector3 velocity = new Vector3(inputs.Movement().x, 0.0f, inputs.Movement().y);

            Vector3 moveDirection = transform.forward * velocity.z + transform.right * velocity.x;

            
            if (!movement.OnSlope() || rigidbody.velocity.y > -0.1f)
            {
                rigidbody.AddForce(moveDirection.normalized * slideForce, ForceMode.Force);

                slideTimer -= Time.deltaTime;
            }

            
            else
            {
                rigidbody.AddForce(movement.GetSlopeMoveDirection(moveDirection) * slideForce, ForceMode.Force);
            }

            if (slideTimer <= 0)
                StopSliding();
        }
    }
}
