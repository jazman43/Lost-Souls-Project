using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace LostSouls.UI.Menus
{
    public class PauseMenu : MonoBehaviour
    {
        
        public void OnPause()
        {
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0;

        }

        public void OnUnPause()
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

        public void OnExit()
        {
           
            Debug.Log("unPause Load menu");
            Time.timeScale = 1;
            
            MenuManager menuManager = FindObjectOfType<MenuManager>();
            menuManager.LoadMenu();
        }
    }
}