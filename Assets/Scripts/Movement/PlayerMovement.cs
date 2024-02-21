using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using LostSouls.Inputs;
using System;

namespace LostSouls.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("move")]
        [SerializeField] private float moveSpeed = Mathf.Infinity;
        [SerializeField] private float walkSpeed = 3.5f;
        [SerializeField] private float sprintSpeed = 7f;
        public Vector3 velocity { get; set; }
        private PlayerInputs inputs;
        private CharacterController controller;
        

        [Header("air movement")]
        [SerializeField] private float airSpeedMultiplier;

        [Header("camera")]        
        [SerializeField] private float turnSmoothTime = 0.1f;
        private float turnSmoothVel;
        

        [Header("jump")]
        [SerializeField] private float jumpForce = 1f;
        [SerializeField] private float groundedOffset = -0.14f;
        [SerializeField] private float groundedRadius = 0.28f;
        [SerializeField] private LayerMask groundLayers;
        [SerializeField] private bool grounded;
        private Vector3 yPosition;
        private float gravity = 0;
        private float normalGravity = -9.81f;
        [SerializeField] private int jumpCharges = 1;
        float wallJumpTimer;
        [SerializeField] private float maxWallJumpTimer;



        [Header("Climbing Wall")]
        [SerializeField] private bool onWall;
        [SerializeField] private float onwallRadius = 0.5f;
        [SerializeField] private LayerMask onWallLayers;



        private WallRun wallrun;



        [Header("Animation")]
        [SerializeField] private string walkAnimation;




        private void Awake()
        {
            controller = GetComponent<CharacterController>();
            inputs = GetComponent<PlayerInputs>();
            wallrun = GetComponent<WallRun>();
        }

        private void Update()
        {
                       
            GroundedCheck();
            ClimbingWallCheck();
            Movement();

            Debug.Log(wallJumpTimer);
        }

        

        public void Movement()
        {
            //input for movement from a vector2 to a vector3
            velocity = new Vector3(inputs.Movement().x, 0.0f, inputs.Movement().y);

            //set speed based of user input
            if (inputs.Sprint())
            {
                moveSpeed = sprintSpeed;
            }
            else
            {
                moveSpeed = walkSpeed;
            }

            if(IsPlayerGrounded() || (wallrun != null && wallrun.IsWallRunning()))
            {
                //check if movement is happening
                if (velocity.magnitude <= 0.1f)
                {
                    moveSpeed = 0;
                }
                else if(IsPlayerGrounded())
                {
                    //set a angle to target where camera is looking
                    float targetAngle = Mathf.Atan2(
                        velocity.x,
                        velocity.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;

                    //smooth the characters movement to direction
                    float angle = Mathf.SmoothDampAngle(
                        transform.eulerAngles.y,
                        targetAngle,
                        ref turnSmoothVel,
                        turnSmoothTime);

                    //preform the character mover in direction based on the angle smoothing
                    transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);

                    //set new angle as forward vector
                    Vector3 moveDirection = Quaternion.Euler(0.0f, targetAngle, 0.0f) * Vector3.forward;


                    velocity = Vector3.Lerp(velocity, moveDirection , moveSpeed * Time.deltaTime);
                    Debug.Log(velocity + " \n " + moveDirection);
                }

                if((IsPlayerGrounded() || (wallrun != null && wallrun.IsWallRunning())) && inputs.Jump())
                {
                    if (IsPlayerGrounded())
                    {
                        // start by canceling out the vertical component of our velocity
                        velocity = new Vector3(velocity.x, 0f, velocity.z);
                        // then, add the jumpSpeed value upwards
                        velocity += Vector3.up * jumpForce;
                    }
                    else
                    {
                        velocity = new Vector3(velocity.x, 0f, velocity.z);
                        // then, add the jumpSpeed value upwards
                        velocity += wallrun.GetWallJumpDirection() * jumpForce;
                    }
                }
            }
            else
            {
                if (wallrun != null && !wallrun.IsWallRunning())
                {
                    
                    velocity += transform.TransformVector(inputs.Movement()) * 25f * Time.deltaTime;

                    
                    float verticalVelocity = velocity.y;
                    Vector3 horizontalVelocity = Vector3.ProjectOnPlane(velocity, Vector3.up);
                    horizontalVelocity = Vector3.ClampMagnitude(horizontalVelocity, 10f * moveSpeed);
                    velocity = horizontalVelocity + (Vector3.up * verticalVelocity);

                    
                    velocity += Vector3.down * normalGravity * Time.deltaTime;
                }
            }
            //move character in direction and at the proper move speed at a fixed rate
            controller.Move(velocity * moveSpeed * Time.deltaTime);

            //animation here


        }

        /*
        private void Griavity()
        {
            
            if (canRunOnWall)
            {
                gravity = wallrunGravity;
            }
            else
            {
                gravity = normalGravity;
            }

            //check if grounded and the Y position is not less then 0 if is set it to 0
            if(controller.isGrounded && yPosition.y < 0)
            {
                yPosition.y = 0.0f;
            }
            //update y position
            yPosition.y += gravity * Time.deltaTime;
            controller.Move(yPosition * Time.deltaTime);


        }

        private void Jump()
        {
            //get input
            if (grounded && !canRunOnWall)
            {
                
                //add force to y position 
                
                if (inputs.Jump())
                {
                    yPosition.y += Mathf.Sqrt(jumpForce * -2.0f * gravity);
                    
                }
                jumpCharges = 1;
                
            }
            else if (inputs.Jump() && jumpCharges >= 1 && !canRunOnWall)
            {
                yPosition.y += Mathf.Sqrt(jumpForce * -1.0f * gravity);
                Debug.Log("double Jump");

                jumpCharges -= 1;
            }
        }

        */
        private void GroundedCheck()
        {
            // set sphere position, with offset
            Vector3 spherePosition = new Vector3(
                transform.position.x,
                transform.position.y - groundedOffset,
                transform.position.z);
            
            grounded = Physics.CheckSphere(
                spherePosition,
                groundedRadius,
                groundLayers,
                QueryTriggerInteraction.Ignore);

            
        }

        public bool IsPlayerGrounded()
        {
            return grounded;
        }

        private void ClimbingWallCheck()
        {

            Vector3 spherePosition = new Vector3(
                transform.position.x,
                transform.position.y + 1,
                transform.position.z + 0.5f);

            onWall = Physics.CheckSphere(
                spherePosition,
                onwallRadius,
                onWallLayers);

            
        }       

        
    }
}
