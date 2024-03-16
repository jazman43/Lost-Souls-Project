using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace LostSouls.Movement
{
    public class ForceReceiver : MonoBehaviour
    {
        [SerializeField] private CharacterController characterController;
        [SerializeField] private float drag = 0.3f;
        private float verticalVel;
        private Vector3 impact;
        private Vector3 dampingVel;

        [SerializeField] private bool grounded;
        [SerializeField] private float groundedOffset = -0.14f;
        [SerializeField] private float groundedRadius = 0.24f;
        [SerializeField] private LayerMask groundLayers;


        public Vector3 Movement => impact + Vector3.up * verticalVel;

        private void Update()
        {
            GroundedCheck();
            if (verticalVel < 0f && grounded)
            {
                verticalVel = Physics.gravity.y * Time.deltaTime;
            }
            else
            {
                verticalVel += Physics.gravity.y * Time.deltaTime;
            }

            impact = Vector3.SmoothDamp(impact, Vector3.zero, ref dampingVel, drag);
        }

        public void AddForce(Vector3 force)
        {
            impact += force;
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
    }
}
