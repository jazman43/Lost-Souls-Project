//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Game/INPUTS/Inputs.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace LostSouls.Inputs
{
    public partial class @Inputs: IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @Inputs()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""Inputs"",
    ""maps"": [
        {
            ""name"": ""PlayerMovement"",
            ""id"": ""c6e7aa76-16d3-4e82-9567-56d844ccba91"",
            ""actions"": [
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""d774e7e0-593f-474e-b01e-06da72a532c6"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""StickDeadzone"",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""38a61684-b4e0-487b-9dff-29be4227b0a1"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""c5385bc0-929e-4990-94cc-9f418d264ba7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""eece5d5c-ecc3-429a-ad9b-62bc02fa3196"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""mousePos"",
                    ""type"": ""Value"",
                    ""id"": ""14c5cceb-f703-498c-b14b-9a65fba00536"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""fd2da40e-7ec2-4c9f-83d8-fde02f7a4b1d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Slide"",
                    ""type"": ""Button"",
                    ""id"": ""7b47814b-0bd9-435f-a103-a321876161e7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Doge"",
                    ""type"": ""Button"",
                    ""id"": ""16f92a77-b34b-4b56-8dde-c5be6e47996e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Target"",
                    ""type"": ""Button"",
                    ""id"": ""2a0da167-6153-4c2d-884b-2924f1fc92d9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""8ed2f1a7-ae4f-4836-8e9f-be84904896a6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""72e7f41f-1b83-4719-9575-472cc97f67a5"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ed5359dc-a2dc-468d-b336-81079d3915e7"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a23a3ace-4471-4f16-a65f-ab729ee26022"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""1d6bef6f-a9ee-4edc-96bd-9093707293b4"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""fad0ff9f-1a69-4a84-9281-a7cff0924ab0"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5777ab77-be52-4b14-b18c-1784ec6b1640"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""5813822a-a4fb-43b5-bd65-d4b53079324d"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""549d66f2-34e0-46fd-81f1-c40ff2c67411"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f7d3dcf9-279d-47e6-be43-9e19951d842f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ed013f48-3ad5-4502-a22a-c4f953fee566"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""affc6db1-6946-43ab-8e39-a6047cf36e3c"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""36d06705-9602-48e4-b911-bc144776bcbf"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f0866e7e-b2e7-4d51-bd4e-cfdeb2ae82c7"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""mousePos"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d2721eb1-583d-486c-9941-872b5bbc3665"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ced38cb9-aa89-43d5-be1a-3b26ba970599"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9f281b58-63b8-4590-b017-f1c6937a45cf"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Slide"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f9e78780-85d9-44ac-8f78-c70dd470ae8d"",
                    ""path"": ""<Gamepad>/rightStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Slide"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3bfde298-271e-4e28-81c7-18996c3cbf22"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Doge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""631eba66-ec55-4c10-8c52-e351ace4ec2a"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Doge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e7a8946e-21f4-45be-805d-ecae6d6178f9"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Target"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b2dc1cbd-6688-4604-ac4a-5e70f18a46ae"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Target"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f5fb44f7-02b6-4d0f-8e68-6263f5a11c4b"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4998e8d6-364c-47af-b17e-12aafae7a1d1"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MenuUI"",
            ""id"": ""3fe7c695-f20b-4647-8ed4-1adba39e5956"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""9e926c86-2d35-4cf7-8da2-dbf4ad4d30bc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2dc6ae1e-5c2f-4977-87ad-d15f33cf7999"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Mouse & Keyboard"",
            ""bindingGroup"": ""Mouse & Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Controller"",
            ""bindingGroup"": ""Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // PlayerMovement
            m_PlayerMovement = asset.FindActionMap("PlayerMovement", throwIfNotFound: true);
            m_PlayerMovement_Look = m_PlayerMovement.FindAction("Look", throwIfNotFound: true);
            m_PlayerMovement_Move = m_PlayerMovement.FindAction("Move", throwIfNotFound: true);
            m_PlayerMovement_Jump = m_PlayerMovement.FindAction("Jump", throwIfNotFound: true);
            m_PlayerMovement_Sprint = m_PlayerMovement.FindAction("Sprint", throwIfNotFound: true);
            m_PlayerMovement_mousePos = m_PlayerMovement.FindAction("mousePos", throwIfNotFound: true);
            m_PlayerMovement_Crouch = m_PlayerMovement.FindAction("Crouch", throwIfNotFound: true);
            m_PlayerMovement_Slide = m_PlayerMovement.FindAction("Slide", throwIfNotFound: true);
            m_PlayerMovement_Doge = m_PlayerMovement.FindAction("Doge", throwIfNotFound: true);
            m_PlayerMovement_Target = m_PlayerMovement.FindAction("Target", throwIfNotFound: true);
            m_PlayerMovement_Attack = m_PlayerMovement.FindAction("Attack", throwIfNotFound: true);
            // MenuUI
            m_MenuUI = asset.FindActionMap("MenuUI", throwIfNotFound: true);
            m_MenuUI_Newaction = m_MenuUI.FindAction("New action", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }

        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }

        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // PlayerMovement
        private readonly InputActionMap m_PlayerMovement;
        private List<IPlayerMovementActions> m_PlayerMovementActionsCallbackInterfaces = new List<IPlayerMovementActions>();
        private readonly InputAction m_PlayerMovement_Look;
        private readonly InputAction m_PlayerMovement_Move;
        private readonly InputAction m_PlayerMovement_Jump;
        private readonly InputAction m_PlayerMovement_Sprint;
        private readonly InputAction m_PlayerMovement_mousePos;
        private readonly InputAction m_PlayerMovement_Crouch;
        private readonly InputAction m_PlayerMovement_Slide;
        private readonly InputAction m_PlayerMovement_Doge;
        private readonly InputAction m_PlayerMovement_Target;
        private readonly InputAction m_PlayerMovement_Attack;
        public struct PlayerMovementActions
        {
            private @Inputs m_Wrapper;
            public PlayerMovementActions(@Inputs wrapper) { m_Wrapper = wrapper; }
            public InputAction @Look => m_Wrapper.m_PlayerMovement_Look;
            public InputAction @Move => m_Wrapper.m_PlayerMovement_Move;
            public InputAction @Jump => m_Wrapper.m_PlayerMovement_Jump;
            public InputAction @Sprint => m_Wrapper.m_PlayerMovement_Sprint;
            public InputAction @mousePos => m_Wrapper.m_PlayerMovement_mousePos;
            public InputAction @Crouch => m_Wrapper.m_PlayerMovement_Crouch;
            public InputAction @Slide => m_Wrapper.m_PlayerMovement_Slide;
            public InputAction @Doge => m_Wrapper.m_PlayerMovement_Doge;
            public InputAction @Target => m_Wrapper.m_PlayerMovement_Target;
            public InputAction @Attack => m_Wrapper.m_PlayerMovement_Attack;
            public InputActionMap Get() { return m_Wrapper.m_PlayerMovement; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerMovementActions set) { return set.Get(); }
            public void AddCallbacks(IPlayerMovementActions instance)
            {
                if (instance == null || m_Wrapper.m_PlayerMovementActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_PlayerMovementActionsCallbackInterfaces.Add(instance);
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
                @mousePos.started += instance.OnMousePos;
                @mousePos.performed += instance.OnMousePos;
                @mousePos.canceled += instance.OnMousePos;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @Slide.started += instance.OnSlide;
                @Slide.performed += instance.OnSlide;
                @Slide.canceled += instance.OnSlide;
                @Doge.started += instance.OnDoge;
                @Doge.performed += instance.OnDoge;
                @Doge.canceled += instance.OnDoge;
                @Target.started += instance.OnTarget;
                @Target.performed += instance.OnTarget;
                @Target.canceled += instance.OnTarget;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
            }

            private void UnregisterCallbacks(IPlayerMovementActions instance)
            {
                @Look.started -= instance.OnLook;
                @Look.performed -= instance.OnLook;
                @Look.canceled -= instance.OnLook;
                @Move.started -= instance.OnMove;
                @Move.performed -= instance.OnMove;
                @Move.canceled -= instance.OnMove;
                @Jump.started -= instance.OnJump;
                @Jump.performed -= instance.OnJump;
                @Jump.canceled -= instance.OnJump;
                @Sprint.started -= instance.OnSprint;
                @Sprint.performed -= instance.OnSprint;
                @Sprint.canceled -= instance.OnSprint;
                @mousePos.started -= instance.OnMousePos;
                @mousePos.performed -= instance.OnMousePos;
                @mousePos.canceled -= instance.OnMousePos;
                @Crouch.started -= instance.OnCrouch;
                @Crouch.performed -= instance.OnCrouch;
                @Crouch.canceled -= instance.OnCrouch;
                @Slide.started -= instance.OnSlide;
                @Slide.performed -= instance.OnSlide;
                @Slide.canceled -= instance.OnSlide;
                @Doge.started -= instance.OnDoge;
                @Doge.performed -= instance.OnDoge;
                @Doge.canceled -= instance.OnDoge;
                @Target.started -= instance.OnTarget;
                @Target.performed -= instance.OnTarget;
                @Target.canceled -= instance.OnTarget;
                @Attack.started -= instance.OnAttack;
                @Attack.performed -= instance.OnAttack;
                @Attack.canceled -= instance.OnAttack;
            }

            public void RemoveCallbacks(IPlayerMovementActions instance)
            {
                if (m_Wrapper.m_PlayerMovementActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IPlayerMovementActions instance)
            {
                foreach (var item in m_Wrapper.m_PlayerMovementActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_PlayerMovementActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public PlayerMovementActions @PlayerMovement => new PlayerMovementActions(this);

        // MenuUI
        private readonly InputActionMap m_MenuUI;
        private List<IMenuUIActions> m_MenuUIActionsCallbackInterfaces = new List<IMenuUIActions>();
        private readonly InputAction m_MenuUI_Newaction;
        public struct MenuUIActions
        {
            private @Inputs m_Wrapper;
            public MenuUIActions(@Inputs wrapper) { m_Wrapper = wrapper; }
            public InputAction @Newaction => m_Wrapper.m_MenuUI_Newaction;
            public InputActionMap Get() { return m_Wrapper.m_MenuUI; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(MenuUIActions set) { return set.Get(); }
            public void AddCallbacks(IMenuUIActions instance)
            {
                if (instance == null || m_Wrapper.m_MenuUIActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_MenuUIActionsCallbackInterfaces.Add(instance);
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }

            private void UnregisterCallbacks(IMenuUIActions instance)
            {
                @Newaction.started -= instance.OnNewaction;
                @Newaction.performed -= instance.OnNewaction;
                @Newaction.canceled -= instance.OnNewaction;
            }

            public void RemoveCallbacks(IMenuUIActions instance)
            {
                if (m_Wrapper.m_MenuUIActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IMenuUIActions instance)
            {
                foreach (var item in m_Wrapper.m_MenuUIActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_MenuUIActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public MenuUIActions @MenuUI => new MenuUIActions(this);
        private int m_MouseKeyboardSchemeIndex = -1;
        public InputControlScheme MouseKeyboardScheme
        {
            get
            {
                if (m_MouseKeyboardSchemeIndex == -1) m_MouseKeyboardSchemeIndex = asset.FindControlSchemeIndex("Mouse & Keyboard");
                return asset.controlSchemes[m_MouseKeyboardSchemeIndex];
            }
        }
        private int m_ControllerSchemeIndex = -1;
        public InputControlScheme ControllerScheme
        {
            get
            {
                if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
                return asset.controlSchemes[m_ControllerSchemeIndex];
            }
        }
        public interface IPlayerMovementActions
        {
            void OnLook(InputAction.CallbackContext context);
            void OnMove(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
            void OnSprint(InputAction.CallbackContext context);
            void OnMousePos(InputAction.CallbackContext context);
            void OnCrouch(InputAction.CallbackContext context);
            void OnSlide(InputAction.CallbackContext context);
            void OnDoge(InputAction.CallbackContext context);
            void OnTarget(InputAction.CallbackContext context);
            void OnAttack(InputAction.CallbackContext context);
        }
        public interface IMenuUIActions
        {
            void OnNewaction(InputAction.CallbackContext context);
        }
    }
}
