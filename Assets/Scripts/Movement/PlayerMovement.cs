using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LostSouls.Inputs;


namespace LostSouls.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("move")]
        [SerializeField] private float moveSpeed = Mathf.Infinity;
        [SerializeField] private float walkSpeed = 3.5f;
        [SerializeField] private float sprintSpeed = 7f;
        private Vector3 velocity;
        private PlayerInputs inputs;
        private CharacterController controller;

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
        private float griavity = -9.81f;
        private bool canDoubleJump;

        [Header("Climbing Wall")]
        [SerializeField] private bool onWall;
        [SerializeField] private float onwallRadius = 0.5f;
        [SerializeField] private LayerMask onWallLayers;


        [Header("Running wall")]
        [SerializeField] private bool runningWallLeft;
        [SerializeField] private bool runningWallRight;
        [SerializeField] private LayerMask onRunningWallLayers;
        [SerializeField] private float rayDistance = 2f;



        [Header("Animation")]
        [SerializeField] private string walkAnimation;




        private void Awake()
        {
            controller = GetComponent<CharacterController>();
            inputs = GetComponent<PlayerInputs>();
        }

        private void Update()
        {
            Movement();


            if (!onWall)
            {
                Griavity();
            }
            
            Jump();
            GroundedCheck();
            ClimbingWallCheck();
            WallRunningCheck();
        }

        
        public void Movement()
        {
            //input for movement from a vector2 to a vector3
            Vector3 moveControl = new Vector3(inputs.Movement().x, 0.0f, inputs.Movement().y);

            //set speed based of user input
            if (inputs.Sprint())
            {
                moveSpeed = sprintSpeed;
            }
            else
            {
                moveSpeed = walkSpeed;
            }

            //check if movement is happening
            if(moveControl.magnitude <= 0.1f)
            {
                moveSpeed = 0;
            }
            else
            {
                //set a angle to target where camera is looking
                float targetAngle = Mathf.Atan2(
                    moveControl.x,
                    moveControl.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;

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

                //move character in direction and at the proper move speed at a fixed rate
                controller.Move(moveDirection.normalized * moveSpeed * Time.deltaTime);
            }
            //animation here
            

        }

        //add griavity 
        private void Griavity()
        {
            //check if grounded and the Y position is not less then 0 if is set it to 0
            if(controller.isGrounded && yPosition.y < 0)
            {
                yPosition.y = 0.0f;
            }
            //update y position
            yPosition.y += griavity * Time.deltaTime;
            controller.Move(yPosition * Time.deltaTime);
        }

        private void Jump()
        {
            //get input
            if (grounded )
            {
                Debug.Log("grounded");
                //add force to y position 
                if (inputs.Jump())
                {
                    yPosition.y += Mathf.Sqrt(jumpForce * -2.0f * griavity);
                }
                
                if (true)
                {
                    canDoubleJump = true;
                }
            }
            else if (inputs.Jump() && canDoubleJump)
            {
                Debug.Log("jumps");
                //check if grounded

                canDoubleJump = false;
            }
        }


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

            Debug.Log(onWall + "yay");
        }

        private void WallRunningCheck()
        {
            Vector3 StartPosition = new Vector3(
                transform.position.x,
                transform.position.y + .6f,
                transform.position.z);

            Vector3 worldDirecrionLeft = transform.TransformDirection(Vector3.left);

            Vector3 worldDirecrionRight = transform.TransformDirection(Vector3.right);

            Ray rayLeft = new Ray(StartPosition, worldDirecrionLeft);
            Ray rayRight = new Ray(StartPosition, worldDirecrionRight);
            RaycastHit hit;


            if(Physics.Raycast(rayLeft, out hit, rayDistance))
            {
                Debug.Log("Hit something: on left " + hit.collider.tag);
            }


            if (Physics.Raycast(rayRight, out hit, rayDistance))
            {
                Debug.Log("Hit something: on right " + hit.collider.tag);
            }

            Debug.DrawRay(rayLeft.origin, rayLeft.direction * rayDistance, Color.red);
            Debug.DrawRay(rayRight.origin, rayRight.direction * rayDistance, Color.red);
            
            
        }
    }
}
