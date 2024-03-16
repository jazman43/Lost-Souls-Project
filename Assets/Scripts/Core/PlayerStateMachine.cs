using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LostSouls.Movement;
using LostSouls.Inputs;
using UnityEngine.Animations;
using LostSouls.combat;

namespace LostSouls.core
{
    public class PlayerStateMachine : StateMachine 
    {
        [field: SerializeField] public PlayerInputs PlayerInputs { get; private set; }
        [field: SerializeField] public CharacterController CharacterController { get; private set; }
        [field: SerializeField] public Animator Animation { get; private set; }
        [field: SerializeField] public Targeter Targeter { get; private set; }
        [field: SerializeField] public ForceReceiver ForceReceiver { get; private set; }
        [field: SerializeField] public float walkSpeed { get; private set; }
        [field: SerializeField] public float SprintSpeed { get; private set; }
        [field: SerializeField] public float RotationSmooth { get; private set; }
        [field: SerializeField] public Attack[] Attacks { get; private set; }
        public Transform MainCameraTransform { get; private set; }

        private void Start()
        {
            MainCameraTransform = Camera.main.transform;

            SwitchState(new PlayerMovementState(this));
        }
    }
}


