using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using LostSouls.Saving;


namespace LostSouls.UI.Menus
{
    public class MenuUI : MonoBehaviour
    {
        [SerializeField] private TMP_InputField inputField;

       public void NewGame()
       {
            FindObjectOfType<MenuManager>().NewGame(inputField.text);
       }


        public void QuitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }

}