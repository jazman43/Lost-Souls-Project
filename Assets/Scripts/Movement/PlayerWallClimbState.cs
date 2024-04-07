using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LostSouls.core;


namespace LostSouls.Movement
{
    public class PlayerWallClimbState : PlayerBaseState
    {
        private Vector3 wallForward;

        private readonly int climbBlendTreeAnimationHash = Animator.StringToHash("ClimbingBlendTree");
        private readonly int climbForwardAnimationHash = Animator.StringToHash("ClimbForward");
        private readonly int climbRightAnimationHash = Animator.StringToHash("ClimbRight");


        public PlayerWallClimbState(PlayerStateMachine stateMachine, Vector3 wallForward) : base(stateMachine)
        {
            this.wallForward = wallForward;
        }

        public override void Enter()
        {
            Debug.Log("enter wall climb state");
            //rotate player in correct direction
            stateMachine.transform.rotation = Quaternion.LookRotation(wallForward, Vector3.up);
            stateMachine.Animation.CrossFadeInFixedTime(climbBlendTreeAnimationHash, 0.1f);
        }

        public override void Tick(float daltaTime)
        {
            //move player up and down on the Y left and right on the X.
            Vector2 movement = stateMachine.PlayerInputs.Movement();

            Vector3 wallRight = Vector3.Cross(Vector3.up, wallForward).normalized;
            Vector3 wallUp = Vector3.Cross(wallForward, wallRight).normalized;

            

            Vector3 movementRalativeToWall = (wallUp * movement.y + wallRight * movement.x) * daltaTime;


            stateMachine.CharacterController.Move(movementRalativeToWall);
            //Debug.Log("enter wall climb state" + wallUp);

            //leave wall
            if (stateMachine.PlayerInputs.Cancel())
            {
                stateMachine.CharacterController.Move(Vector3.zero);

                stateMachine.ForceReceiver.Reset();

                stateMachine.SwitchState(new PlayerFallingState(stateMachine));
            }
            else if (stateMachine.PlayerInputs.Jump())
            {
                //stateMachine.ForceReceiver.Reset();
                Vector3 pushDir = -wallForward;

                stateMachine.ForceReceiver.AddForce(pushDir * 6);
                Debug.Log(pushDir * 6);
                stateMachine.SwitchState(new PlayerJumpingState(stateMachine));
            }

            UpdateAnimator(daltaTime);
        }

        public override void Exit()
        {
            
        }



        private void UpdateAnimator(float daltaTime)
        {
            if (stateMachine.PlayerInputs.Movement().y == 0)
            {
                stateMachine.Animation.SetFloat(climbForwardAnimationHash, 0, 0.1f, daltaTime);

            }
            else
            {
                float value = stateMachine.PlayerInputs.Movement().y > 0 ? 1f : -1f;
                stateMachine.Animation.SetFloat(climbForwardAnimationHash, value, 0.1f, daltaTime);
            }

            if (stateMachine.PlayerInputs.Movement().x == 0)
            {
                stateMachine.Animation.SetFloat(climbRightAnimationHash, 0, 0.1f, daltaTime);

            }
            else
            {
                float value = stateMachine.PlayerInputs.Movement().x > 0 ? 1f : -1f;
                stateMachine.Animation.SetFloat(climbRightAnimationHash, value, 0.1f, daltaTime);
            }
        }
    }
}

