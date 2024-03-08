using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LostSouls.Inputs;



namespace LostSouls.Movement
{
    public class Climbing : MonoBehaviour
    {
        [Header("Reference")]
        [SerializeField] private Rigidbody rbody;
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private LayerMask wall;
        [SerializeField] private PlayerInputs inputs;

        [Header("Climbing")]
        [SerializeField] private float climbSpeed;
        [SerializeField] private float maxClimbTime;
        private float climberTimer;

        private bool climbing;

        [Header("ClimbingJumping")]
        [SerializeField] private float climbJumpUpForce;
        [SerializeField] private float climbJumpBackForce;

        [SerializeField] private int climbJumps;
        private int climbJumpsLeft;

        [Header("Detection")]
        [SerializeField] private float detectionLength;
        [SerializeField] private float sphereCastRadius;
        [SerializeField] private float maxWallLookAngle;
        private float wallLookAngle;

        private RaycastHit frontWallHit;
        private bool wallFront;

        private Transform lastWall;
        private Vector3 lastWallNormal;
        [SerializeField] private float minWallNormalAngleChange;

        [Header("Exiting")]
        [SerializeField] private bool exitingWall;
        [SerializeField] private float exitWallTime;
        private float exitWallTimer;


        private void Update()
        {
            WallCheck();
            StateMachine();

            if (climbing && !exitingWall) ClimbingMovement();
        }

        private void StateMachine()
        {
            
            if (wallFront && inputs.Movement().y > 0.1f && wallLookAngle < maxWallLookAngle && !exitingWall)
            {
                if (!climbing && climberTimer > 0) StartClimbing();

                
                if (climberTimer > 0) climberTimer -= Time.deltaTime;
                if (climberTimer < 0) StopClimbing();
            }

            
            else if (exitingWall)
            {
                if (climbing) StopClimbing();

                if (exitWallTimer > 0) exitWallTimer -= Time.deltaTime;
                if (exitWallTimer < 0) exitingWall = false;
            }

            
            else
            {
                if (climbing) StopClimbing();
            }

            if (wallFront && inputs.Jump() && climbJumpsLeft > 0) ClimbJump();
        }

        private void WallCheck()
        {
            wallFront = Physics.SphereCast(transform.position, sphereCastRadius, transform.forward, out frontWallHit, detectionLength, wall);
            wallLookAngle = Vector3.Angle(transform.forward, -frontWallHit.normal);

            bool newWall = frontWallHit.transform != lastWall || Mathf.Abs(Vector3.Angle(lastWallNormal, frontWallHit.normal)) > minWallNormalAngleChange;

            if ((wallFront && newWall) || playerMovement.IsPlayerGrounded())
            {
                climberTimer = maxClimbTime;
                climbJumpsLeft = climbJumps;
            }
        }

        private void StartClimbing()
        {
            climbing = true;
            playerMovement.climbing = true;

            lastWall = frontWallHit.transform;
            lastWallNormal = frontWallHit.normal;

            /// idea - camera fov change
        }

        private void ClimbingMovement()
        {
            GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, climbSpeed, GetComponent<Rigidbody>().velocity.z);

            /// idea - sound effect
        }

        private void StopClimbing()
        {
            climbing = false;
            playerMovement.climbing = false;

            /// idea - particle effect
            /// idea - sound effect
        }

        private void ClimbJump()
        {
            exitingWall = true;
            exitWallTimer = exitWallTime;

            Vector3 forceToApply = transform.up * climbJumpUpForce + frontWallHit.normal * climbJumpBackForce;

            GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, 0f, GetComponent<Rigidbody>().velocity.z);
            GetComponent<Rigidbody>().AddForce(forceToApply, ForceMode.Impulse);

            climbJumpsLeft--;
        }
    }

}