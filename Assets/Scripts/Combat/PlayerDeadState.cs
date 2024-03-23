using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LostSouls.core;




namespace LostSouls.combat
{
    public class PlayerDeadState : PlayerBaseState
    {
        public PlayerDeadState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            stateMachine.Ragdoll.ToggleRagdoll(true);
            for(int i =0; i < stateMachine.WeaponDamage.Length; i++)
            {
                stateMachine.WeaponDamage[i].gameObject.SetActive(false);
            }
            
        }

        public override void Tick(float daltaTime)
        {
            
        }

        public override void Exit()
        {
            
        }

        
    }
}
