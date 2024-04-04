using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LostSouls.core;


namespace LostSouls.Movement
{
    public class PlayerHangingState : PlayerBaseState
    {
        Vector3 closestPoint;
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

                Vector3 movement = new Vector3();
                movement.y = 0;
                movement.z = 0;
                movement.x = stateMachine.PlayerInputs.Movement().x;

                stateMachine.transform.rotation = Quaternion.LookRotation(ledgeForward, Vector3.up);

                stateMachine.CharacterController.Move(movement * daltaTime);
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
            }

           

        }

        public override void Exit()
        {
            
        }

        
    }
}

