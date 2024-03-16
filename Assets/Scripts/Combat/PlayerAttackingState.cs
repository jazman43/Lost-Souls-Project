using LostSouls.core;
using LostSouls.Movement;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




namespace LostSouls.combat
{
    public class PlayerAttackingState : PlayerBaseState
    {
        private float previousFrameTime;
        private bool alreadyAppliedForce;

        private Attack attack;

        public PlayerAttackingState(PlayerStateMachine stateMachine, int attackIndex) : base(stateMachine)
        {
            attack = stateMachine.Attacks[attackIndex];
        }

        public override void Enter()
        {
            Debug.Log("enterAttacking" + attack.AnimationName);
            stateMachine.Animation.CrossFadeInFixedTime(attack.AnimationName, attack.TransitionTime);
        }

        public override void Tick(float daltaTime)
        {
            Move(daltaTime);

            FaceTarget();

            float normalizedTime = GetNormalizedTime();

            if(normalizedTime >= previousFrameTime && normalizedTime < 1f)
            {
                if(normalizedTime >= attack.ForceTime)
                {
                    TryApplyForce();
                }

                if (stateMachine.PlayerInputs.Attack())
                {
                    TryComboAttack(normalizedTime);
                }
                else
                {
                    if (stateMachine.Targeter.currentTarget != null)
                    {
                        stateMachine.SwitchState(new PlayerTargetingState(stateMachine));
                    }
                    else
                    {
                        stateMachine.SwitchState(new PlayerMovementState(stateMachine));
                    }
                }
            }

            previousFrameTime = normalizedTime;
        }

       

        public override void Exit()
        {
            
        }

        private float GetNormalizedTime()
        {
            AnimatorStateInfo currentInfo = stateMachine.Animation.GetCurrentAnimatorStateInfo(0);
            AnimatorStateInfo nextInfo = stateMachine.Animation.GetNextAnimatorStateInfo(0);

            if(stateMachine.Animation.IsInTransition(0) && nextInfo.IsTag("Attack"))
            {
                return nextInfo.normalizedTime;
            }
            else if(!stateMachine.Animation.IsInTransition(0) && currentInfo.IsTag("Attack"))
            {
                return currentInfo.normalizedTime;
            }
            else
            {
                return 0f;
            }
        }

        private void TryComboAttack(float normalizedTime)
        {
            if (attack.ComboStateIndex == -1) return;

            if (normalizedTime < attack.ComboAttackTime) return;

            stateMachine.SwitchState
                (
                    new PlayerAttackingState
                    (
                        stateMachine,
                        attack.ComboStateIndex
                    )
                );
            
        }

        private void TryApplyForce()
        {
            if (alreadyAppliedForce) return;

            stateMachine.ForceReceiver.AddForce(stateMachine.transform.forward * attack.Force);

            alreadyAppliedForce = true;
        }
    }
}
