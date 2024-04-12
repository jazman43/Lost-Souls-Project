using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LostSouls.core;
using System;
using LostSouls.combat;

namespace LostSouls.Movement
{
    public class PlayerMovementState : PlayerBaseState
    {
        private bool shouldFade;

        private readonly int freeLookBlendTreeAnimationHash = Animator.StringToHash("FreeLookBlendTree");
        private readonly int moveAnimationHash = Animator.StringToHash("Move");
        private const float animatorDampTime = 0.1f;

        public PlayerMovementState(PlayerStateMachine stateMachine, bool shouldFade  =  true) : base(stateMachine)
        {
            this.shouldFade = shouldFade;
        }

       
        Vector3 velocity;

        public override void Enter()
        {
            Debug.Log("enter");

            Cursor.lockState = CursorLockMode.Locked;

            stateMachine.Animation.SetFloat(moveAnimationHash, 0);

            if (shouldFade)
            {
                stateMachine.Animation.CrossFadeInFixedTime(freeLookBlendTreeAnimationHash, 0.1f);
            }
            else
            {
                stateMachine.Animation.Play(freeLookBlendTreeAnimationHash);
            }

            
        }

        

        public override void Tick(float daltaTime)
        {
            if (stateMachine.PlayerInputs.Target()) { OnTarget(); }
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

            velocity = CalculateMovement();

            //Debug.Log(velocity);
            if (stateMachine.PlayerInputs.Sprint())
            {
                Move(velocity * stateMachine.SprintSpeed, daltaTime);
                
            }
            else
            {
                Move(velocity * stateMachine.walkSpeed, daltaTime);
                //stateMachine.Animation.SetFloat(moveAnimationHash, 1, animatorDampTime, daltaTime);
            }
            

            if (stateMachine.PlayerInputs.Movement() == Vector2.zero)
            {
                stateMachine.Animation.SetFloat(moveAnimationHash, 0, animatorDampTime, daltaTime);
                return;
            }
            stateMachine.Animation.SetFloat(moveAnimationHash, 1.8f, animatorDampTime, daltaTime);

            FaceMovementDirection(daltaTime);
        }

        public override void Exit()
        {
            Debug.Log("Exit");
           
        }

        private Vector3 CalculateMovement()
        {
            Vector3 forward = stateMachine.MainCameraTransform.forward;
            Vector3 right = stateMachine.MainCameraTransform.right;

            forward.y = 0f;
            right.y = 0f;

            forward.Normalize();
            right.Normalize();

            return forward * stateMachine.PlayerInputs.Movement().y +
                right * stateMachine.PlayerInputs.Movement().x;
        }

        private void FaceMovementDirection(float daltaTime)
        {
            stateMachine.transform.rotation = Quaternion.Lerp(
                stateMachine.transform.rotation,
                Quaternion.LookRotation(velocity),
                daltaTime * stateMachine.RotationSmooth);
        }

        private void OnTarget()
        {
            if (!stateMachine.Targeter.SelectTarget()) return;

            stateMachine.SwitchState(new PlayerTargetingState(stateMachine));
        }
    }

}