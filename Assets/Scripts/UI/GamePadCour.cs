using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Users;
using LostSouls.Inputs;


namespace LostSouls.UI
{
    public class GamePadCour : MonoBehaviour
    {
        private PlayerInput playerInput;
        private RectTransform canvas;
        private Canvas canvasMain;
        private RectTransform cursorTransform;
        private RectTransform[] allRectTransforms;
        private Mouse virtualMouse;

        private bool previseState;

        [SerializeField] private float cursorSpeed = 1000f;

        private void Awake()
        {
            playerInput = FindObjectOfType<PlayerInput>();
            allRectTransforms = FindObjectsOfType<RectTransform>();
            for (int i = 0; i < allRectTransforms.Length; i++)
            {
                if (allRectTransforms[i].CompareTag("Cursor"))
                {
                    cursorTransform = allRectTransforms[i];


                }
                if (allRectTransforms[i].CompareTag("Canvas"))
                {
                    canvas = allRectTransforms[i];
                    canvasMain = allRectTransforms[i].gameObject.GetComponent<Canvas>();

                }
            }
        }


        private void OnEnable()
        {
            if (virtualMouse == null)
            {
                virtualMouse = (Mouse)InputSystem.AddDevice("VirtualMouse");
            }
            else if (!virtualMouse.added)
            {
                InputSystem.AddDevice(virtualMouse);
            }

            InputUser.PerformPairingWithDevice(virtualMouse, playerInput.user);

            if(cursorTransform != null)
            {
                Vector2 position = cursorTransform.anchoredPosition;
                InputState.Change(virtualMouse.position, position);
            }

            InputSystem.onAfterUpdate += UpdateMotion;
        }

        private void OnDisable()
        {
            InputSystem.RemoveDevice(virtualMouse);
            InputSystem.onAfterUpdate -= UpdateMotion;
        }

        private void UpdateMotion()
        {
            if(virtualMouse == null || Gamepad.current == null) return;

            Vector2 stickValue = Gamepad.current.leftStick.ReadValue();

            stickValue *= cursorSpeed * Time.deltaTime;

            Vector2 currentPosition = virtualMouse.position.ReadValue();

            Vector2 newPosition = currentPosition + stickValue;

            newPosition.x = Mathf.Clamp(newPosition.x, 0, Screen.width);
            newPosition.y = Mathf.Clamp(newPosition.y, 0, Screen.height);

            InputState.Change(virtualMouse.position, newPosition);
            InputState.Change(virtualMouse.delta, stickValue);

            if(previseState != Gamepad.current.buttonSouth.IsPressed())
            {
                virtualMouse.CopyState<MouseState>(out var mouseState);

                mouseState.WithButton(MouseButton.Left, Gamepad.current.buttonSouth.IsPressed());

                InputState.Change(virtualMouse, mouseState);

                previseState = Gamepad.current.buttonSouth.IsPressed();
            }

            AnchorCursor(newPosition);
        }


        private void AnchorCursor(Vector2 position)
        {
            Vector2 anchoredPosition;

            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, position, canvasMain.renderMode == RenderMode.ScreenSpaceOverlay ? null : Camera.main, out anchoredPosition);

            cursorTransform.anchoredPosition = anchoredPosition;
        }
    }
}
