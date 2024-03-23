using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LostSouls.Inputs;
using UnityEngine.UI;
using LostSouls.core;


namespace LostSouls.UI.Menus
{
    public class ShowHidePauseMenu : MonoBehaviour
    {
        PlayerInputs inputs;
        [SerializeField] private string safeZoneString = "safeZone";
        [SerializeField] private PauseMenu pauseMenu;
        [SerializeField] private RectTransform HUD;
        [SerializeField] private Button testButtons;

        bool canPause;
        bool isPaused;

        private void Awake()
        {
            inputs = GetComponent<PlayerInputs>();
        }



        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(safeZoneString))
            {
                canPause = true;
                Debug.Log("Can pause");
                
                
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(safeZoneString))
            {
                canPause = false;
            }
        }

        private void Update()
        {

            

            if (inputs.Menu() && canPause)
            {
                Debug.Log(inputs.Menu());
                isPaused = true;
                HUD.gameObject.SetActive(false);
                pauseMenu.gameObject.SetActive(true);
                pauseMenu.OnPause();
                inputs.gameObject.GetComponent<PlayerStateMachine>().enabled = false;
            }

            /*if (inputs.Menu() && isPaused && pauseMenu.gameObject.activeSelf)
            {
                isPaused = false;
                UnPause();
            }*/
        }

        public void UnPause()
        {
            inputs.gameObject.GetComponent<PlayerStateMachine>().enabled = false;
            HUD.gameObject.SetActive(true);
            pauseMenu.gameObject.SetActive(false);
            pauseMenu.OnUnPause();
        }
    }

}