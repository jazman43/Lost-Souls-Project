using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LostSouls.Saving;
using LostSouls.SceneManagement;



namespace LostSouls.UI.Menus
{
    public class MenuManager : MonoBehaviour
    {

        const string defaultSaveFile = "Save";
        [SerializeField] float fadeInTime = 0.2f;
        [SerializeField] float fadeOutTime = 0.2f;
        [SerializeField] int firstLevelBuildIndex = 1;
        [SerializeField] int menuLevelBuildIndex = 0;
        




        public void ContinueGame()
        {
            if (!PlayerPrefs.HasKey(defaultSaveFile)) return;
            if (GetComponent<SavingSystem>().SaveExists(GetCurrentSave())) return;
            Debug.Log("Loading.. continue");
            StartCoroutine(LoadLastScene());
        }

        public void NewGame(string saveFile)
        {
            if (string.IsNullOrEmpty(saveFile)) return;
            SetCurrentSave(saveFile);
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
            Fader fader = FindObjectOfType<Fader>();
            Debug.Log("loading last Scene");
            yield return fader.FadeOut(fadeOutTime);
            yield return GetComponent<SavingSystem>().LoadLastScene(GetCurrentSave());
            yield return fader.FadeIn(fadeInTime);
        }

        private IEnumerator LoadFirstScene()
        {
            Fader fader = FindObjectOfType<Fader>();
            Cursor.lockState = CursorLockMode.Locked;
            yield return fader.FadeOut(fadeOutTime);
            yield return SceneManager.LoadSceneAsync(firstLevelBuildIndex);
            yield return fader.FadeIn(fadeInTime);
        }

        private IEnumerator LoadMenuScene()
        {
            Fader fader = FindObjectOfType<Fader>();
            
            yield return fader.FadeOut(fadeOutTime);
            Debug.Log("Load Menu Scene" );
            
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(menuLevelBuildIndex);

            while (!asyncLoad.isDone)
            {
                Debug.Log("UnLoad Menu Scene");
                yield return null;
            }
            //BUG nothing after this point is called 
            Debug.Log("UnLoad Menu Scene");
            yield return fader.FadeIn(fadeInTime);
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


        
    }
}

