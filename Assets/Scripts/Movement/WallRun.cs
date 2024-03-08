using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using LostSouls.Inputs;


namespace LostSouls.Movement
{
    public class WallRun : MonoBehaviour
    {
        [Header("Wallrunning")]
        [SerializeField] private LayerMask wall;
        [SerializeField] private LayerMask ground;
        [SerializeField] private float wallRunForce;
        [SerializeField] private float wallClimbSpeed;
        [SerializeField] private float maxWallRunTime;
        private float wallRunTimer;

        [Header("Input")]
        private bool upwardsRunning;
        private bool downwardsRunning;
        private float horizontalInput;
        private float verticalInput;

        [Header("Detection")]
        [SerializeField] private float wallCheckDistance;
        [SerializeField] private float minJumpHeight;
        private RaycastHit leftWallhit;
        private RaycastHit rightWallhit;
        private bool wallLeft;
        private bool wallRight;

        [Header("References")]
        private PlayerInputs inputs;
        private PlayerMovement playerMovement;
        private Rigidbody rbody;

        private void Awake()
        {
            rbody = GetComponent<Rigidbody>();
            playerMovement = GetComponent<PlayerMovement>();
            inputs = GetComponent<PlayerInputs>();
        }

        private void Update()
        {
            CheckForWall();
            StateMachine();
        }

        private void FixedUpdate()
        {
            if (playerMovement.wallRunning)
                WallRunningMovement();
        }

        private void CheckForWall()
        {
            wallRight = Physics.Raycast(transform.position, transform.right, out rightWallhit, wallCheckDistance, wall);
            wallLeft = Physics.Raycast(transform.position, -transform.right, out leftWallhit, wallCheckDistance, wall);

            Debug.DrawRay(transform.position, transform.right * wallCheckDistance, Color.red);
            Debug.DrawRay(transform.position, -transform.right * wallCheckDistance, Color.red);
        }

        private bool AboveGround()
        {
            return !Physics.Raycast(transform.position, Vector3.down, minJumpHeight, ground);
        }

        private void StateMachine()
        {

            upwardsRunning = inputs.Movement().y > 0.1;
            downwardsRunning = inputs.Movement().y < -0.1;

            // State 1 - Wallrunning
            if ((wallLeft || wallRight) && verticalInput > 0 && AboveGround())
            {
                if (!playerMovement.wallRunning)
                    StartWallRun();
            }

            // State 3 - None
            else
            {
                if (playerMovement.wallRunning)
                    StopWallRun();
            }
        }

        private void StartWallRun()
        {
            playerMovement.wallRunning = true;
        }

        private void WallRunningMovement()
        {
            rbody.useGravity = false;
            rbody.velocity = new Vector3(rbody.velocity.x, 0f, rbody.velocity.z);

            Vector3 wallNormal = wallRight ? rightWallhit.normal : leftWallhit.normal;

            Vector3 wallForward = Vector3.Cross(wallNormal, transform.up);

            if ((transform.forward - wallForward).magnitude > (transform.forward - -wallForward).magnitude)
                wallForward = -wallForward;

            // forward force
            rbody.AddForce(wallForward * wallRunForce, ForceMode.Force);

            // upwards/downwards force
            if (upwardsRunning)
                rbody.velocity = new Vector3(rbody.velocity.x, wallClimbSpeed, rbody.velocity.z);
            if (downwardsRunning)
                rbody.velocity = new Vector3(rbody.velocity.x, -wallClimbSpeed, rbody.velocity.z);

            // push to wall force
            if (!(wallLeft && horizontalInput > 0) && !(wallRight && horizontalInput < 0))
                rbody.AddForce(-wallNormal * 100, ForceMode.Force);
        }

        private void StopWallRun()
        {
            playerMovement.wallRunning = false;
        }
    }
}