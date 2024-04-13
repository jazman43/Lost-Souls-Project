using UnityEngine;
using Fungus;
using LostSouls.core;
using Cinemachine;

namespace LostSouls.Dialog
{
    public class DialogPlayerLock : MonoBehaviour
    {

        private PlayerStateMachine playerStateMachine;
        private CinemachineBrain cinemachineBrain;

        private void Start()
        {
            playerStateMachine = FindObjectOfType<PlayerStateMachine>();  // Get Player's StateMachine
            cinemachineBrain = FindObjectOfType<CinemachineBrain>(); //Get Cinemachine Brain
        }

        public void SetMovementLock(bool locked) // Lock or Unlock PlayerMovement
        {
            if (playerStateMachine || cinemachineBrain != null)
            {
                playerStateMachine.enabled = !locked;
                cinemachineBrain.enabled = !locked;
            }
            else
            {
                Debug.LogError("Can not find PlayerStateMachine");
            }
        }
    }
}