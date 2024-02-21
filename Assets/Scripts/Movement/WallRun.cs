using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using LostSouls.Inputs;


namespace LostSouls.Movement
{
    public class WallRun : MonoBehaviour
    {
        [Header("Running wall")]
        [SerializeField] private float wallMaxDistance = 1;
        [SerializeField] private float wallSpeedMultiplier = 1.2f;
        [SerializeField] private float minimumHeight = 1.2f;
        [SerializeField] private float maxAngleRoll = 20;
        [Range(0.0f, 1.0f)]
        [SerializeField] private float normalizedAngleThreshold = 0.1f;

        [SerializeField] private float jumpDuration = 1;
        [SerializeField] private float wallBouncing = 3;
        [SerializeField] private float cameraTransitionDuration = 1;

        [SerializeField] private float wallGravityDownForce = 20f;

        [SerializeField] private bool useSprint;
        

        Vector3[] directions;
        RaycastHit[] hits;

        bool isWallRunning = false;
        Vector3 lastWallPosition;
        Vector3 lastWallNormal;
        float elapsedTimeSinceJump = 0;
        float elapsedTimeSinceWallAttach = 0;
        float elapsedTimeSinceWallDetatch = 0;
        bool jumping;
        

        private PlayerInputs inputs;
        


        private void Awake()
        {            
            inputs = GetComponent<PlayerInputs>();
        }

        private bool isPlayerGrounded()
        {
            return GetComponent<PlayerMovement>().IsPlayerGrounded();
        }

        public bool IsWallRunning()
        {
            return isWallRunning;
        }

        bool canWallRun()
        {
            float verticalAxis = inputs.Movement().magnitude;
            bool isSprinting = inputs.Sprint();

            return !isPlayerGrounded() && verticalAxis > 0 && VerticalCheck() && isSprinting;
        }

        bool VerticalCheck()
        {
            return !Physics.Raycast(transform.position, Vector3.down, minimumHeight);
        }

        private void Start()
        {
            directions = new Vector3[]
            {
                Vector3.right,
                Vector3.right + Vector3.forward,
                Vector3.forward,
                Vector3.left + Vector3.forward,
                Vector3.left
            };


        }


        private void LateUpdate()
        {
            isWallRunning = false;

            if (inputs.Jump())
            {
                jumping = true;
            }


            if (CanAttach())
            {
                hits = new RaycastHit[directions.Length];

                for(int i = 0;i < directions.Length; i++)
                {
                    Vector3 dir = transform.TransformDirection(directions[i]);

                    Physics.Raycast(transform.position, dir, out hits[i], wallMaxDistance);

                    if(hits[i].collider != null)
                    {
                        Debug.DrawRay(transform.position, dir * hits[i].distance, Color.green);
                    }
                    else
                    {
                        Debug.DrawRay(transform.position, dir * wallMaxDistance, Color.red);
                    }
                }

                if (canWallRun())
                {
                    hits = hits.ToList().Where(h => h.collider != null).OrderBy(h => h.distance).ToArray();

                    if(hits.Length > 0)
                    {
                        OnWall(hits[0]);
                        lastWallPosition = hits[0].point;
                        lastWallNormal = hits[0].normal;
                    }
                }
            }

            if (isWallRunning)
            {
                elapsedTimeSinceWallDetatch = 0;
                elapsedTimeSinceWallAttach += Time.deltaTime;

                GetComponent<PlayerMovement>().velocity += Vector3.down * wallGravityDownForce * Time.deltaTime;
            }
            else
            {
                elapsedTimeSinceWallAttach = 0;
               
                elapsedTimeSinceWallDetatch += Time.deltaTime;
            }

        }

        bool CanAttach()
        {
            if (jumping)
            {
                elapsedTimeSinceJump += Time.deltaTime;
                if (elapsedTimeSinceJump > jumpDuration)
                {
                    elapsedTimeSinceJump = 0;
                    jumping = false;
                }
                return false;
            }
            return true;
        }


        void OnWall(RaycastHit hit)
        {
            float d = Vector3.Dot(hit.normal, Vector3.up);
            if (d >= -normalizedAngleThreshold && d <= normalizedAngleThreshold)
            {
                
                float vertical = inputs.Movement().x;
                Vector3 alongWall = transform.TransformDirection(Vector3.forward);

                Debug.DrawRay(transform.position, alongWall.normalized * 10, Color.green);
                Debug.DrawRay(transform.position, lastWallNormal * 10, Color.magenta);

                GetComponent<PlayerMovement>().velocity = alongWall * vertical * wallSpeedMultiplier;
                isWallRunning = true;
            }
        }


        float CalculateSide()
        {
            if (isWallRunning)
            {
                Vector3 heading = lastWallPosition - transform.position;
                Vector3 perp = Vector3.Cross(transform.forward, heading);
                float dir = Vector3.Dot(perp, transform.up);
                return dir;
            }
            return 0;
        }

        public Vector3 GetWallJumpDirection()
        {
            if (isWallRunning)
            {
                return lastWallNormal * wallBouncing + Vector3.up;
            }
            return Vector3.zero;
        }
        
    }
}