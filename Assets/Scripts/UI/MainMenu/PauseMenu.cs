using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace LostSouls.UI.Menus
{
    public class PauseMenu : MonoBehaviour
    {
        private void OnEnable()
        {
            Debug.Log("PauseGame!");            

            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0;
            
        }



        private void OnDisable()
        {
            Debug.Log("UNPauseGame!");
            
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
            
        }

        public void Save()
        {
            MenuManager menuManager = FindObjectOfType<MenuManager>();
            menuManager.SaveGameState();
        }
    }
}