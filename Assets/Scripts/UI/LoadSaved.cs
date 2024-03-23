using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using LostSouls.UI.Menus;


namespace LostSouls.UI
{
    public class LoadSaved : MonoBehaviour
    {
        [SerializeField] Transform contentRoot;
        [SerializeField] GameObject buttonPrefab;

        private void OnEnable()
        {
            MenuManager savingWrapper = FindObjectOfType<MenuManager>();
            if (savingWrapper == null) return;
            foreach (Transform child in contentRoot)
            {
                Destroy(child.gameObject);
            }
            foreach (string save in savingWrapper.ListSaves())
            {
                Debug.Log(save);
                GameObject buttonInstance = Instantiate(buttonPrefab, contentRoot);
                TMP_Text textComp = buttonInstance.GetComponentInChildren<TMP_Text>();
                textComp.text = save;
                Button button = buttonInstance.GetComponentInChildren<Button>();
                button.onClick.AddListener(() =>
                {
                    savingWrapper.LoadGame(save);
                });
            }
        }
    }
}

