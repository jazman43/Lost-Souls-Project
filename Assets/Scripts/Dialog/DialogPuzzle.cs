using UnityEngine;
using Fungus;
using LostSouls.core;

namespace LostSouls.Dialog
{
    public class DialogPuzzle : MonoBehaviour
    {

        private PlayerStateMachine playerStateMachine;

        private void Start()
        {
            playerStateMachine = FindObjectOfType<PlayerStateMachine>();  // Get Player's StateMachine
        }

        public void SetMovementLock(bool locked) // Lock or Unlock PlayerMovement
        {
            if (playerStateMachine != null)
            {
                playerStateMachine.enabled = !locked;
            }
            else
            {
                Debug.LogError("Can not find PlayerStateMachine");
            }
        }
    }
}