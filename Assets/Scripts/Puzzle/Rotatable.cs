using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LostSouls.Interact;
using LostSouls.Inputs;

namespace LostSouls.Puzzles
{
    public class Rotatable : MonoBehaviour, IRaycastAble
    {
        private float currentRotationAngle = 0f;

        [SerializeField] private float speed = 5f;

        public bool HandleRaycast(Interact.Interact callingInteract)
        {
            if (FindObjectOfType<PlayerInputs>().Interact())
            {
                Debug.Log("rotate");
                Rotate();
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
            
            while (Quaternion.Angle(transform.rotation, targetRotation) > 0.01f)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed);
                yield return null;
            }

           
            transform.rotation = targetRotation;
        }
    }

}