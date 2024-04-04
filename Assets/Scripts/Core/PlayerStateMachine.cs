using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LostSouls.Movement;
using LostSouls.Inputs;
using UnityEngine.Animations;
using LostSouls.combat;
using LostSouls.Saving;


namespace LostSouls.core
{
    public class PlayerStateMachine : StateMachine ,ISaveable
    {
        [field: SerializeField] public PlayerInputs PlayerInputs { get; private set; }
        [field: SerializeField] public CharacterController CharacterController { get; private set; }
        [field: SerializeField] public Animator Animation { get; private set; }
        [field: SerializeField] public Targeter Targeter { get; private set; }
        [field: SerializeField] public ForceReceiver ForceReceiver { get; private set; }
        [field: SerializeField] public PlayerHealth PlayerHealth { get; private set; }
        [field: SerializeField] public Health Health { get; private set; }
        [field: SerializeField] public Ragdoll Ragdoll { get; private set; }
        [field: SerializeField] public LedgeDetector LedgeDetector { get; private set; }
        [field: SerializeField] public WeaponDamage[] WeaponDamage { get; private set; }
        [field: SerializeField] public float walkSpeed { get; private set; }
        [field: SerializeField] public float SprintSpeed { get; private set; }
        [field: SerializeField] public float RotationSmooth { get; private set; }
        [field: SerializeField] public float DodgeDuration { get; private set; }
        [field: SerializeField] public float DodgeLength { get; private set; }
        [field: SerializeField] public float JumpForce { get; private set; }
        [field: SerializeField] public Attack[] Attacks { get; private set; }
        public Transform MainCameraTransform { get; private set; }

        private void Start()
        {
            MainCameraTransform = Camera.main.transform;

            SwitchState(new PlayerMovementState(this));
        }

        private void OnEnable()
        {
            Health.OnDie += HandleOnDie;
            //PlayerHealth.OnDie += HandleOnDie;
        }

        private void OnDisable()
        {
            Health.OnDie -= HandleOnDie;
            //PlayerHealth.OnDie -= HandleOnDie;
        }

        private void HandleOnDie()
        {
            SwitchState(new PlayerDeadState(this));
        }

        public object CaptureState()
        {
            return new SerializableVector3(transform.position);
        }

        public void RestoreState(object state)
        {
            SerializableVector3 position = (SerializableVector3)state;
            transform.position = position.ToVector();
        }
    }
}


