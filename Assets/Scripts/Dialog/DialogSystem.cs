using UnityEngine;
using Fungus;
using LostSouls.core;
using Cinemachine;
using LostSouls.Saving;


namespace LostSouls.Dialog
{
 
    public class DialogSystem: MonoBehaviour, ISaveable
    {

        private PlayerStateMachine playerStateMachine;
        private CinemachineBrain cinemachineBrain;
        private bool isFirstDialogShown = false; 
        private void Start()
        {
            playerStateMachine = FindObjectOfType<PlayerStateMachine>();  // Get Player's StateMachine
            cinemachineBrain = FindObjectOfType<CinemachineBrain>(); //Get Cinemachine
            if (!isFirstDialogShown)
            {
                isFirstDialogShown = true; //Flag for activated dialog
                SetIsAlreadySaid();
            }
                                                                   
        }

        public void SetMovementLock(bool locked) // Lock or Unlock PlayerMovement
        {
            if (playerStateMachine != null && cinemachineBrain != null)
            {
                playerStateMachine.enabled = !locked;
                cinemachineBrain.enabled = !locked;
            }
            else
            {
                Debug.LogError("Can not find PlayerStateMachine");
            }
        }
        public void SetIsAlreadySaid() // No more opening dialog when its alreay actiivated
        {
            GameObject[] dialogs = GameObject.FindGameObjectsWithTag("Dialog");
            foreach (GameObject dialog in dialogs)
                {
                    dialog.SetActive(false);
                }
            }

        public object CaptureState()
        {
            throw new System.NotImplementedException();
        }

        public void RestoreState(object state)
        {
            throw new System.NotImplementedException();
        }
    }
}