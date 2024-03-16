using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using LostSouls.Inputs;
using System;
using UnityEngine.Animations;
using LostSouls.Saving;


namespace LostSouls.Movement
{
    public class PlayerMovement : MonoBehaviour , ISaveable
    {
        [Header("move")]
        [SerializeField] private float moveSpeed = Mathf.Infinity;
        [SerializeField] private float walkSpeed = 3.5f;
        [SerializeField] private float sprintSpeed = 7f;
        [SerializeField] private float climbSpeed = 7f;
        public Vector3 velocity { get; set; }
        [SerializeField] Transform orientation;
        private Vector3 moveDirection;
        private PlayerInputs inputs;
        private Rigidbody Rigidbody;        
        [SerializeField]private float groundDrag;
        [SerializeField] private float wallrunSpeed;
        [SerializeField] private float slideSpeed;

        private float desiredMoveSpeed;
        private float lastDesiredMoveSpeed;

        public bool sliding;

        [SerializeField] private float speedIncreaseMultiplier;
        [SerializeField] private float slopeIncreaseMultiplier;

        [Header("air movement")]
        [SerializeField] private float airSpeedMultiplier;

        [Header("camera")]

        [Header("Crouching")]
        [SerializeField] private float crouchSpeed;
        [SerializeField] private float crouchYScale;
        private float startYScale;
        private float playerHeight;

        [Header("Slope Handling")]
        [SerializeField] private float maxSlopeAngle;
        private RaycastHit slopeHit;
        private bool exitingSlope;


        [Header("jump")]
        [SerializeField] private float jumpForce = 1f;
        [SerializeField] private float groundedOffset = -0.14f;
        [SerializeField] private float groundedRadius = 0.28f;
        [SerializeField] private LayerMask groundLayers;
        [SerializeField] private bool grounded;
        [SerializeField] private float jumpCoolDown;
        bool readyToJump;
        

        private WallRun wallrun;

        public bool climbing;
        public bool wallRunning;

        public State state;
        public enum State
        {
            walking,
            sprinting,
            crouching,
            sliding,
            air,
            climbing,
            wallRunning
        }

        [Header("Animation")]
        [SerializeField] private string moveAnimation;
        [SerializeField] private string jumpAnimation;
        [SerializeField] private string inAirAnimation;
        private Animator animator;
        

        private void Awake()
        {
            animator = GetComponentInChildren<Animator>();
            inputs = GetComponent<PlayerInputs>();
            wallrun = GetComponent<WallRun>();
            Rigidbody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            readyToJump = true;
            startYScale = transform.localScale.y;

           // Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            
            GroundedCheck();
            Jump();
            SpeedControl();
            //Crouch();
            StateHandler();


            if (grounded)
            {
                Rigidbody.drag = groundDrag;
            }
            {
                Rigidbody.drag = 0;
            }
        }

        private void StateHandler()
        {
            /*
             * locked off as it frezzes game when on slopes
             * 
            if (sliding)
            {
                state = State.sliding;

                if (OnSlope() && Rigidbody.velocity.y < 0.1f)
                    desiredMoveSpeed = slideSpeed;

                else
                    desiredMoveSpeed = sprintSpeed;
            }
            */
            /*
            if (inputs.Crouch())
            {
                state = State.crouching;
                desiredMoveSpeed = crouchSpeed;
            }
            */
            if (wallRunning)
            {
                state = State.wallRunning;
                desiredMoveSpeed = wallrunSpeed;
                Debug.Log("in wall running state");
            }
            else if (climbing)
            {
                state = State.climbing;

                desiredMoveSpeed = climbSpeed;
            }
            else if (grounded && inputs.Sprint())
            {
                state = State.sprinting;
                desiredMoveSpeed = sprintSpeed;
            }            
            else if (grounded)
            {
                state = State.walking;
                desiredMoveSpeed = walkSpeed;
                animator.SetBool(inAirAnimation, false);
            }            
            else
            {
                state = State.air;
            }

            if (!grounded)
            {
                animator.SetBool(inAirAnimation, true);
                
            }

            
            if (Mathf.Abs(desiredMoveSpeed - lastDesiredMoveSpeed) > 4f && moveSpeed != 0)
            {
                StopAllCoroutines();
                StartCoroutine(SmoothlyLerpMoveSpeed());
            }
            else
            {
                moveSpeed = desiredMoveSpeed;
            }

            lastDesiredMoveSpeed = desiredMoveSpeed;

            Debug.Log(moveSpeed);
        }

        private void Rotation()
        {
            Ray cameraRay = UnityEngine.Camera.main.ScreenPointToRay(inputs.Mouse());
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayLength;

            if (groundPlane.Raycast(cameraRay, out rayLength))
            {
                Vector3 pointToLook = cameraRay.GetPoint(rayLength);
                transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
            }
        }

        private void FixedUpdate()
        {
            Movement();
            Rotation();
            
        }

        public void Movement()
        {
            //input for movement from a vector2 to a vector3
            velocity = new Vector3(inputs.Movement().x, 0.0f, inputs.Movement().y);

            moveDirection = transform.forward * velocity.z + transform.right * velocity.x;

            //Debug.Log(moveDirection);

            if (OnSlope() && !exitingSlope)
            {
                Rigidbody.AddForce(GetSlopeMoveDirection(moveDirection) * moveSpeed * 20f, ForceMode.Force);

                if (Rigidbody.velocity.y > 0)
                    Rigidbody.AddForce(Vector3.down * 80f, ForceMode.Force);
            }

            if (grounded)
            {
                Debug.Log("Move " + moveSpeed);
                Rigidbody.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
            }else if (!grounded)
            {
                Rigidbody.AddForce(moveDirection.normalized * moveSpeed * 10f * airSpeedMultiplier, ForceMode.Force);
            }

            animator.SetFloat(moveAnimation, moveDirection.magnitude);           
           
            Rigidbody.useGravity = !OnSlope();
        }

        private void SpeedControl()
        {
            if (OnSlope() && !exitingSlope)
            {
                if (Rigidbody.velocity.magnitude > moveSpeed)
                    Rigidbody.velocity = Rigidbody.velocity.normalized * moveSpeed;
            }

            Vector3 flatVel = new Vector3(Rigidbody.velocity.x, 0f, Rigidbody.velocity.z);

            if(flatVel.magnitude > moveSpeed)
            {
                Vector3 limitVel = flatVel.normalized* moveSpeed;
                Rigidbody.velocity = new Vector3(limitVel.x, Rigidbody.velocity.y, limitVel.z);
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

        public bool IsPlayerGrounded()
        {
            return grounded;
        }

         
        void Jump()
        {
            if (inputs.Jump() && readyToJump && grounded)            
            {
                animator.SetTrigger(jumpAnimation);

                readyToJump = false;

                exitingSlope = true;

                Rigidbody.velocity = new Vector3(Rigidbody.velocity.x, 0f, Rigidbody.velocity.z);

                Rigidbody.AddForce(transform.up * jumpForce, ForceMode.Impulse);

                Invoke(nameof(ResetJump), jumpCoolDown);
            }
        }

        void ResetJump()
        {
            readyToJump = true;

            exitingSlope = false;
        }

        public bool OnSlope()
        {
            if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.3f))
            {
                float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
                return angle < maxSlopeAngle && angle != 0;
            }

            return false;
        }

        public Vector3 GetSlopeMoveDirection(Vector3 moveDir)
        {
            return Vector3.ProjectOnPlane(moveDir, slopeHit.normal).normalized;
        }


        void Crouch()
        {
            if (inputs.Crouch())
            {
                transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);

                while (!grounded)
                {
                    Rigidbody.AddForce(Vector3.down * 5f, ForceMode.Impulse);
                }
                
                                
            }

            
            if (!inputs.Crouch())
            {
                transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);                
            }
        }

       
        private IEnumerator SmoothlyLerpMoveSpeed()
        {
            
            float time = 0;
            float difference = Mathf.Abs(desiredMoveSpeed - moveSpeed);
            float startValue = moveSpeed;

            while (time < difference)
            {
                moveSpeed = Mathf.Lerp(startValue, desiredMoveSpeed, time / difference);

                if (OnSlope())
                {
                    float slopeAngle = Vector3.Angle(Vector3.up, slopeHit.normal);
                    float slopeAngleIncrease = 1 + (slopeAngle / 90f);

                    time += Time.deltaTime * speedIncreaseMultiplier * slopeIncreaseMultiplier * slopeAngleIncrease;
                }
                else
                    time += Time.deltaTime * speedIncreaseMultiplier;

                yield return null;
            }

            moveSpeed = desiredMoveSpeed;
        }

        public object CapturState()
        {
            return new SerializableVector3(transform.position);
        }

        public void RestoreState(object state)
        {
            SerializableVector3 position = (SerializableVector3)state;

            transform.position = position.ToVector();
        }
    }
}
