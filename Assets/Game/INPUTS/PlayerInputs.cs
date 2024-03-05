using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



namespace LostSouls.Inputs
{
    public class PlayerInputs : MonoBehaviour
    {
        private Inputs input;


        private void Awake()
        {
            input = new Inputs();
        }

        private void OnEnable()
        {
            input.Enable();
        }

        private void OnDisable()
        {
            input.Disable();
        }


        public Vector2 Movement()
        {
            return input.PlayerMovement.Move.ReadValue<Vector2>();
        }

        public bool Jump()
        {
            return input.PlayerMovement.Jump.WasPressedThisFrame();
        }

        public bool Sprint()
        {
            return input.PlayerMovement.Sprint.IsPressed();
        }

        public Vector2 Look()
        {
            return input.PlayerMovement.Look.ReadValue<Vector2>();
        }

        public Vector2 Mouse()
        {
            return input.PlayerMovement.mousePos.ReadValue<Vector2>();
        }

        public bool Crouch()
        {
            return input.PlayerMovement.Crouch.IsPressed();
        }

        public bool Slide()
        {
            return input.PlayerMovement.Slide.IsPressed();
        }
    }
}
