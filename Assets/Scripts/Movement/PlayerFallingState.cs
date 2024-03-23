using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LostSouls.core;
using System;

namespace LostSouls.Movement
{
    public class PlayerFallingState : PlayerBaseState
    {
        private readonly int FallinHash = Animator.StringToHash("Falling To Landing");

        private Vector3 momentum;

        public PlayerFallingState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            momentum = stateMachine.CharacterController.velocity;
            momentum.y = 0;


            stateMachine.Animation.CrossFadeInFixedTime(FallinHash, 0.1f);
        }

        public override void Tick(float daltaTime)
        {
            Move(momentum, daltaTime);

            stateMachine.LedgeDetector.OnLedgeDetect += HandleLedgeDetect;

            Debug.Log(stateMachine.ForceReceiver.IsGournded() + " landing");
            if (stateMachine.ForceReceiver.IsGournded())
            {
                
                ReturnToLocomotion();
            }

            FaceTarget();
        }

       

        public override void Exit()
        {
            stateMachine.LedgeDetector.OnLedgeDetect -= HandleLedgeDetect;
        }

        private void HandleLedgeDetect(Vector3 ledgeForward)
        {
            stateMachine.SwitchState(new PlayerHangingState(stateMachine, ledgeForward));
        }
    }
}
