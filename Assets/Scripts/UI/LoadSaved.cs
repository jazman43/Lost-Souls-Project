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
        [SerializeField] GameObject deteleOrLoadPopUp;

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
                Button button = GetSaves(save);
                button.onClick.AddListener(() =>
                {
                    deteleOrLoadPopUp.SetActive(true);

                    Debug.Log("open Delete or load pop up " + deteleOrLoadPopUp.activeSelf);
                    foreach (Button deteleOrSave in deteleOrLoadPopUp.GetComponentsInChildren<Button>())
                    {
                        if (deteleOrSave.CompareTag("deleteButton"))
                        {
                            Debug.Log("can Delete");
                            deteleOrSave.onClick.AddListener(() =>
                            {
                                Debug.Log("can Delete");
                                savingWrapper.Delete(save);

                                deteleOrLoadPopUp.SetActive(false);
                            });
                        }
                        else
                        {
                            deteleOrSave.onClick.AddListener(() =>
                            {
                                savingWrapper.LoadGame(save);
                                deteleOrLoadPopUp.SetActive(false);
                            });
                        }
                    }
                });
            }


        }

        private Button GetSaves(string save)
        {
            GameObject buttonInstance = Instantiate(buttonPrefab, contentRoot);
            TMP_Text textComp = buttonInstance.GetComponentInChildren<TMP_Text>();
            textComp.text = save;
            Button button = buttonInstance.GetComponentInChildren<Button>();
            return button;
        }
    }
}

