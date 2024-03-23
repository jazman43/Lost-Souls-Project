using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LostSouls.core;
using System;
using LostSouls.Movement;
using LostSouls.combat;



namespace LostSouls.combat
{
    public class PlayerTargetingState : PlayerBaseState
    {

       

        private readonly int targetingBlendTreeAnimationHash = Animator.StringToHash("TargetingBlendTree");
        private readonly int targetingForwardAnimationHash = Animator.StringToHash("TargetingForward");
        private readonly int targetingRightAnimationHash = Animator.StringToHash("TargetingRight");

        public PlayerTargetingState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            Debug.Log("enter Targeting");
            stateMachine.Animation.CrossFadeInFixedTime(targetingBlendTreeAnimationHash, 0.1f);
        }

        public override void Tick(float daltaTime)
        {
            if (stateMachine.PlayerInputs.Doge()) { OnDodge(); }
            if (!stateMachine.PlayerInputs.Target()) { OffTarget(); }

            if (stateMachine.PlayerInputs.Attack())
            {
                stateMachine.SwitchState(new PlayerAttackingState(stateMachine, 0));
                return;
            }
            if (stateMachine.PlayerInputs.Jump())
            {
                stateMachine.SwitchState(new PlayerJumpingState(stateMachine));
                return;
            }
            if (stateMachine.Targeter.currentTarget == null)
            {
                stateMachine.SwitchState(new PlayerMovementState(stateMachine));
                return;
            }

            Vector3 movement = CalculateMovement(daltaTime);
            Move(movement * stateMachine.walkSpeed, daltaTime);

            UpdateAnimator(daltaTime);

            FaceTarget();
        }

        

        public override void Exit()
        {
            
        }

        private void OffTarget()
        {
            stateMachine.Targeter.Cancel();

            stateMachine.SwitchState(new PlayerMovementState(stateMachine));
        }

        private Vector3 CalculateMovement(float deltaTime)
        {
            Vector3 movement = new Vector3();

            movement += stateMachine.transform.right * stateMachine.PlayerInputs.Movement().x;
            movement += stateMachine.transform.forward * stateMachine.PlayerInputs.Movement().y;
            
            
            return movement;
        }

        private void UpdateAnimator(float daltaTime)
        {
            if(stateMachine.PlayerInputs.Movement().y == 0)
            {
                stateMachine.Animation.SetFloat(targetingForwardAnimationHash, 0, 0.1f,daltaTime);

            }
            else
            {
                float value = stateMachine.PlayerInputs.Movement().y > 0 ? 1f : -1f;
                stateMachine.Animation.SetFloat(targetingForwardAnimationHash, value, 0.1f, daltaTime);
            }

            if (stateMachine.PlayerInputs.Movement().x == 0)
            {
                stateMachine.Animation.SetFloat(targetingRightAnimationHash, 0, 0.1f, daltaTime);

            }
            else
            {
                float value = stateMachine.PlayerInputs.Movement().x > 0 ? 1f : -1f;
                stateMachine.Animation.SetFloat(targetingRightAnimationHash, value, 0.1f, daltaTime);
            }
        }

        private void OnDodge()
        {
            stateMachine.SwitchState(new PlayerDodgingState(stateMachine, stateMachine.PlayerInputs.Movement()));
        }
    }
}
