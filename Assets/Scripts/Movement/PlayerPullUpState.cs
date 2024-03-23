using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LostSouls.core;



namespace LostSouls.Movement
{
    public class PlayerPullUpState : PlayerBaseState
    {
        private readonly int PullUpHash = Animator.StringToHash("ClimbingUpLedge");

        public PlayerPullUpState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            Debug.Log("Pull up");
            stateMachine.Animation.CrossFadeInFixedTime(PullUpHash, 0.1f);
        }

        public override void Tick(float daltaTime)
        {
            if (stateMachine.Animation.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f) { return; }

            stateMachine.CharacterController.enabled = false;
            

            stateMachine.transform.Translate(0f, 1.7f, 0.5f, Space.Self);

            stateMachine.CharacterController.enabled = true;

            stateMachine.SwitchState(new PlayerMovementState(stateMachine, false));
        }

        public override void Exit()
        {
            Debug.Log("exit pull up");
            stateMachine.CharacterController.Move(Vector3.zero);
            stateMachine.ForceReceiver.Reset();
        }

        
       
    }

}