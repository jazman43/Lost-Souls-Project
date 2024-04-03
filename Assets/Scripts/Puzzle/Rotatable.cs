using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LostSouls.Interact;
using LostSouls.Interact.UI;
using LostSouls.Inputs;

namespace LostSouls.Puzzles
{
    public class Rotatable : MonoBehaviour, IRaycastAble
    {
        private float currentRotationAngle = 0f;
        private bool isRotating;
        [SerializeField] private float speed = 5f;
        public int puzzleNumber;
        [SerializeField] private float puzzleAnswer;//must be set to "0, 90, -180, -90"

        public bool HandleRaycast(Interact.Interact callingInteract)
        {
            //spwan text
            GetComponentInChildren<InteratUIPopup>().SpawnInteractableText();

            if (FindObjectOfType<PlayerInputs>().Interact())
            {
                
                if (!isRotating)
                {
                    Debug.Log("rotate");
                    Rotate();
                }
                
            }

            return true;
        }

        public void Rotate()
        {
            currentRotationAngle += 90f;

            
            if (currentRotationAngle >= 360f)
            {
                currentRotationAngle -= 360f;
            }

            
            Quaternion targetRotation = Quaternion.Euler(0, currentRotationAngle, 0);

            
            StartCoroutine(RotateTowards(targetRotation));
        }

        private IEnumerator RotateTowards(Quaternion targetRotation)
        {
            isRotating = true;
            while (Quaternion.Angle(transform.rotation, targetRotation) > 0.01f)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed);
                yield return null;
            }

            isRotating = false;
            transform.rotation = targetRotation;
        }

        public bool PuzzleAnswerCheck()
        {
            Quaternion correctRotation = Quaternion.Euler(0, puzzleAnswer, 0);
            
            if (Quaternion.Angle(transform.rotation, correctRotation) < 1f)
            {
                Debug.Log("puzzle answered");
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}