using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;




namespace LostSouls.UI.Menus
{
    public class Settings : MonoBehaviour
    {
        [SerializeField] private string masterVolume = "masterVolume";
        [SerializeField] private AudioMixer audioMixer;
        [SerializeField] private TMP_Dropdown resolutionDropdown;

        Vector2 res;
        Resolution[] resolutions;

        private void Start()
        {
            resolutions = Screen.resolutions;

            resolutionDropdown.ClearOptions();

            List<string> options = new List<string>();

            int currentResolutionIndex = 0; 

            for(int i =0; i < resolutions.Length; i++)
            {
                string option = resolutions[i].width + "x" + resolutions[i].height;

                options.Add(option);

                if(resolutions[i].width == Screen.currentResolution.width &&
                    resolutions[i].height == Screen.currentResolution.height)
                {
                    currentResolutionIndex = i;
                }
            }

            resolutionDropdown.AddOptions(options);
            resolutionDropdown.value = currentResolutionIndex;
            resolutionDropdown.RefreshShownValue();
        }


        //video

        public void SetResolution(int resolutionIndex)
        {
            Resolution resolution = resolutions[resolutionIndex];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
            res = new Vector2(resolution.width, resolution.height);
        }

        public void SetQuality(int graphicsIndex)
        {
            QualitySettings.SetQualityLevel(graphicsIndex);
        }

        public void SetFullscreen(bool isFullscreen)
        {
            Screen.fullScreen = isFullscreen;
        }

        public Vector2 GetResolution()
        {
            return res;
        }

        //sound

        public void SetVolume(float volume)
        {
            audioMixer.SetFloat(masterVolume, volume);
            Debug.Log(volume);
        }

        //controls

    }

}