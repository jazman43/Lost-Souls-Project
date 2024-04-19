using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LostSouls.UI.Menus;
using Fungus;


namespace LostSouls.SceneManagement
{
    public class Portal : MonoBehaviour
    {
        enum DestinationIdentifier
        {
            A, B, C, D, E, F
        }


        [SerializeField] private float fadeInTime = 3f;
        [SerializeField] private float fadeOutTime = 3f;
        [SerializeField] private float fadeWaitTime = 1f;
        [SerializeField] private int sceneIndex = -1;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private DestinationIdentifier destination;
        [SerializeField] private string playerTag = "Player";


        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == playerTag)
            {
                StartCoroutine(Transition());
                Debug.Log("PLayer Hit");
            }
            Debug.Log("Traving..");
            Debug.Log(other.tag);
        }


        public void OnUIClick()
        {
            if (!gameObject.activeInHierarchy)
            {
                gameObject.SetActive(true);
            }

            Debug.Log("Start Game");
            StartCoroutine(Transition());
        }

        private IEnumerator Transition()
        {
            if (sceneIndex < 0)
            {
                Debug.LogError("Scene Not Set!");
                yield break;
            }

            DontDestroyOnLoad(gameObject);

            Fader fader = FindObjectOfType<Fader>();
            MenuManager savingWrapper = FindObjectOfType<MenuManager>();

           
            

            yield return fader.FadeOut(fadeOutTime);

            savingWrapper.SaveGameState();

            yield return SceneManager.LoadSceneAsync(sceneIndex);

            
           

            Debug.Log("Travaling...");


            savingWrapper.LoadGameState();



            Portal otherPortal = GetOtherPortal();
            UpdatePlayer(otherPortal);

            savingWrapper.SaveGameState();

            yield return new WaitForSeconds(fadeWaitTime);

            fader.FadeIn(fadeInTime);


            
            Destroy(gameObject);
        }

        private void UpdatePlayer(Portal otherPortal)
        {
            GameObject player = GameObject.FindWithTag("Player");          
            
            player.transform.rotation = otherPortal.spawnPoint.rotation;
        }

        private Portal GetOtherPortal()
        {
            foreach (Portal portal in FindObjectsOfType<Portal>())
            {
                if (portal == this)
                {
                    continue;
                }
                if (portal.destination != destination) continue;

                return portal;
            }

            return null;
        }
    }

}