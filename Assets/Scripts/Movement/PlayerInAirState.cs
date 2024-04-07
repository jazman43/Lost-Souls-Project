using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LostSouls.core;
using System;

namespace LostSouls.Movement
{
    public class PlayerInAirState : PlayerBaseState
    {
        private readonly int InAirHash = Animator.StringToHash("Falling Idle");

        private Vector3 momentum;

       

        public PlayerInAirState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            momentum = stateMachine.CharacterController.velocity;
            momentum.y = 0;

            stateMachine.Animation.CrossFadeInFixedTime(InAirHash, 0.1f);
        }

        public override void Tick(float daltaTime)
        {
            Move(momentum, daltaTime);

            stateMachine.LedgeDetector.OnLedgeDetect += HandleLedgeDetect;
            stateMachine.WallDetector.OnWallDetect += HandleWallDetect;

            stateMachine.SwitchState(new PlayerFallingState(stateMachine));
            

            FaceTarget();
            
        }

        

        public override void Exit()
        {
            stateMachine.LedgeDetector.OnLedgeDetect -= HandleLedgeDetect;
            stateMachine.WallDetector.OnWallDetect -= HandleWallDetect;
        }

        private void HandleLedgeDetect( Vector3 ledgeForward)
        {
            stateMachine.SwitchState(new PlayerHangingState(stateMachine, ledgeForward));
        }

        private void HandleWallDetect(Vector3 wallForward)
        {
            stateMachine.SwitchState(new PlayerWallClimbState(stateMachine, wallForward));
        }
    }
}
