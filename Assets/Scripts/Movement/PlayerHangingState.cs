using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LostSouls.core;


namespace LostSouls.Movement
{
    public class PlayerHangingState : PlayerBaseState
    {
        //Vector3 closestPoint;
        Vector3 ledgeForward;

        private readonly int hangingIdleHash = Animator.StringToHash("Hanging Idle");

        public PlayerHangingState(PlayerStateMachine stateMachine , Vector3 ledgeForward) : base(stateMachine)
        {
            
            this.ledgeForward = ledgeForward;
        }

        public override void Enter()
        {
            stateMachine.transform.rotation = Quaternion.LookRotation(ledgeForward, Vector3.up);

            stateMachine.Animation.CrossFadeInFixedTime(hangingIdleHash, 0.1f);
        }

        public override void Tick(float daltaTime)
        {

            if(stateMachine.PlayerInputs.Movement().x > 0 || stateMachine.PlayerInputs.Movement().x < 0)
            {
                // move character left and right

                Vector2 movement = stateMachine.PlayerInputs.Movement();

                Vector3 wallRight = Vector3.Cross(Vector3.up, ledgeForward).normalized;
                

                Vector3 movementRalativeToWall = ( wallRight * movement.x) * daltaTime;


                stateMachine.CharacterController.Move(movementRalativeToWall);
            }


            if (stateMachine.PlayerInputs.Movement().y > 0.1f)
            {
                stateMachine.SwitchState(new PlayerPullUpState(stateMachine));
            }
            else if (stateMachine.PlayerInputs.Cancel())
            {
                stateMachine.CharacterController.Move(Vector3.zero);

                stateMachine.ForceReceiver.Reset();

                stateMachine.SwitchState(new PlayerFallingState(stateMachine));
            }else if (stateMachine.PlayerInputs.Jump())
            {
                stateMachine.ForceReceiver.Reset();
                stateMachine.ForceReceiver.AddForce(Vector3.back);
                stateMachine.SwitchState(new PlayerJumpingState(stateMachine));
                
            }

           

        }

        public override void Exit()
        {
            
        }

        
    }
}

