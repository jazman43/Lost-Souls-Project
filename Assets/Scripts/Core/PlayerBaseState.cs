using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LostSouls.combat;
using LostSouls.Movement;



namespace LostSouls.core
{
    public abstract class PlayerBaseState : State
    {
        protected PlayerStateMachine stateMachine;

        public PlayerBaseState(PlayerStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        protected void Move(Vector3 motion, float deltaTime)
        {
            stateMachine.CharacterController.Move((motion + stateMachine.ForceReceiver.Movement) * deltaTime);
        }

        protected void Move( float deltaTime)
        {
            Move(Vector3.zero, deltaTime);
        }

        protected void FaceTarget()
        {
            if (stateMachine.Targeter.currentTarget == null) return;

            Vector3 lookPos = stateMachine.Targeter.currentTarget.transform.position - stateMachine.transform.position;

            lookPos.y = 0f;

            stateMachine.transform.rotation = Quaternion.LookRotation(lookPos);
        }

        protected void ReturnToLocomotion()
        {
            if(stateMachine.Targeter.currentTarget != null)
            {
                stateMachine.SwitchState(new PlayerTargetingState(stateMachine));
            }
            else
            {
                stateMachine.SwitchState(new PlayerMovementState(stateMachine));
            }
        }
    }

}