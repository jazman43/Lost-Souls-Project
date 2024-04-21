using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using LostSouls.core;
using Cinemachine;
using LostSouls.Saving;


namespace LostSouls.Dialog
{
 
    public class DialogSystem: MonoBehaviour, ISaveable
    {

        [SerializeField] private GameObject sayDialog;
        private PlayerStateMachine playerStateMachine;
        private CinemachineBrain cinemachineBrain;
        private CinemachineVirtualCamera virtualCamera;
        private bool isFirstDialogShown = true;


        private void Awake()
        {
            playerStateMachine = FindObjectOfType<PlayerStateMachine>();  // Get Player's StateMachine
            cinemachineBrain = FindObjectOfType<CinemachineBrain>(); //Get Cinemachine
            virtualCamera = FindObjectOfType<CinemachineVirtualCamera>(); //Get VirtualCamera
        }

        private void Start()
        {
            SetIsAlreadySaid(isFirstDialogShown);
        }

        public void SetMovementLock(bool locked) // Lock or Unlock PlayerMovement
        {
            if (playerStateMachine != null)
            {
                playerStateMachine.enabled = !locked;

                if (cinemachineBrain != null)
                {
                    cinemachineBrain.enabled = !locked;
                   if (virtualCamera !=null)
                    {
                        virtualCamera.enabled = !locked;
                    }
                    else
                    {
                        Debug.LogWarning("Can not find virtual Camera");
                    }
                } else
                {
                    Debug.LogWarning("Can not find cinemachine");
                }
                
            }
            else
            {
                Debug.LogError("Can not find PlayerStateMachine");
            }
        }

        public void SetIsAlreadySaid(bool isAlreadySaid) // No more opening dialog when its alreay activated
        {
            
            isFirstDialogShown = isAlreadySaid;
            
            Debug.Log("Dialog is off:  " + isFirstDialogShown);

            if (isFirstDialogShown)
            {
                this.gameObject.GetComponent<Flowchart>().SendFungusMessage("Start");
            }
            
                        
        }

        public object CaptureState()
        {
            Debug.Log("dialog " + isFirstDialogShown);
            return isFirstDialogShown;
        }

        public void RestoreState(object state)
        {
            
            isFirstDialogShown = (bool)state;
            Debug.Log("dialog Loading " + isFirstDialogShown);
        }
    }
}