using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LostSouls.core;
using System;

namespace LostSouls.Movement
{
    public class PlayerJumpingState : PlayerBaseState
    {
        private readonly int JumpHash = Animator.StringToHash("Jumping Up");

        private Vector3 momentum;

        public PlayerJumpingState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            stateMachine.ForceReceiver.Jump(stateMachine.JumpForce);
            momentum = stateMachine.CharacterController.velocity;
            momentum.y = 0;

            stateMachine.Animation.CrossFadeInFixedTime(JumpHash, 0.1f);

            stateMachine.LedgeDetector.OnLedgeDetect += HandleLedgeDetect;
            stateMachine.WallDetector.OnWallDetect += HandleWallDetect;
        }

        

        public override void Tick(float daltaTime)
        {
            Move(momentum, daltaTime);

            if (stateMachine.CharacterController.velocity.y < 0)
            {
                stateMachine.SwitchState(new PlayerInAirState(stateMachine));
                return;
            }

            FaceTarget();
        }

        public override void Exit()
        {
            stateMachine.LedgeDetector.OnLedgeDetect -= HandleLedgeDetect;
            stateMachine.WallDetector.OnWallDetect -= HandleWallDetect;
        }

        private void HandleLedgeDetect(Vector3 ledgeForward)
        {
            stateMachine.SwitchState(new PlayerHangingState(stateMachine, ledgeForward));
        }

        private void HandleWallDetect(Vector3 wallForward)
        {
            stateMachine.SwitchState(new PlayerWallClimbState(stateMachine, wallForward));
        }
    }

}