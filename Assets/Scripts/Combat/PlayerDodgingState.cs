using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LostSouls.core;


namespace LostSouls.combat
{
    public class PlayerDodgingState : PlayerBaseState
    {
        private Vector3 dodgingDirectionInput;
        private float remainingDodgeTime;

        public PlayerDodgingState(PlayerStateMachine stateMachine, Vector3 dodgingDirectionInput) : base(stateMachine)
        {
            this.dodgingDirectionInput = dodgingDirectionInput;
        }

        public override void Enter()
        {
            remainingDodgeTime = stateMachine.DodgeDuration;
            Debug.Log("enter Dodge");
        }

        public override void Tick(float daltaTime)
        {
            Vector3 movement = new Vector3();

            movement += stateMachine.transform.right * dodgingDirectionInput.x * stateMachine.DodgeLength / stateMachine.DodgeDuration;
            movement += stateMachine.transform.forward * dodgingDirectionInput.y * stateMachine.DodgeLength / stateMachine.DodgeDuration;

            Move(movement, daltaTime);

            FaceTarget();

            remainingDodgeTime -= daltaTime;

            if(remainingDodgeTime <= 0f)
            {
                stateMachine.SwitchState(new PlayerTargetingState(stateMachine));
            }
        }

        public override void Exit()
        {
            
        }

    }
}
