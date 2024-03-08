using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LostSouls.Saving;




namespace LostSouls.UI.Menus
{
    public class MenuManager : MonoBehaviour
    {

        const string defaultSaveFile = "Save";

        [SerializeField] int firstLevelBuildIndex = 1;
        [SerializeField] int menuLevelBuildIndex = 0;
        [SerializeField] TMPro.TMP_InputField newGameName;




        public void ContinueGame()
        {
            if (!PlayerPrefs.HasKey(defaultSaveFile)) return;
            if (GetComponent<SavingSystem>().SaveExists(GetCurrentSave())) return;
            Debug.Log("Loading.. continue");
            StartCoroutine(LoadLastScene());
        }

        public void NewGame()
        {
            if (string.IsNullOrEmpty(newGameName.text)) return;
            SetCurrentSave(newGameName.text);
            StartCoroutine(LoadFirstScene());
        }

        public void LoadGame(string saveFile)
        {
            SetCurrentSave(saveFile);
            ContinueGame();
        }

        public void LoadMenu()
        {
            StartCoroutine(LoadMenuScene());
        }



        private void SetCurrentSave(string saveFile)
        {
            Debug.Log(saveFile);
            PlayerPrefs.SetString(defaultSaveFile, saveFile);
        }

        private string GetCurrentSave()
        {
            return PlayerPrefs.GetString(defaultSaveFile);
        }


        private IEnumerator LoadLastScene()
        {

            Debug.Log("loading last Scene");

            yield return GetComponent<SavingSystem>().LoadLastScene(GetCurrentSave());

        }

        private IEnumerator LoadFirstScene()
        {

            Cursor.lockState = CursorLockMode.Locked;

            yield return SceneManager.LoadSceneAsync(firstLevelBuildIndex);

        }

        private IEnumerator LoadMenuScene()
        {

            yield return SceneManager.LoadSceneAsync(menuLevelBuildIndex);
            Cursor.lockState = CursorLockMode.Confined;

        }



        public void SaveGameState()
        {
            GetComponent<SavingSystem>().Save(GetCurrentSave());
        }

        public void LoadGameState()
        {
            GetComponent<SavingSystem>().Load(GetCurrentSave());
        }

        public void Delete()
        {
            GetComponent<SavingSystem>().Delete(GetCurrentSave());
        }

        public IEnumerable<string> ListSaves()
        {
            return GetComponent<SavingSystem>().ListSaves();
        }


        public void QuitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }
    }
}

