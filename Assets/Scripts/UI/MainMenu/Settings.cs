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
        [SerializeField] private string masterVolume = "MasterVolume";
        [SerializeField] private string sfxVolume = "SFX Volume";
        [SerializeField] private float masterVolumeValue;
        [SerializeField] private Slider masterVolumeSlider;

        [SerializeField] private AudioMixer audioMixer;
        [SerializeField] private TMP_Dropdown resolutionDropdown;
        [SerializeField] private TMP_Dropdown qulityDropdown;

        private int resolutionIndex;
        private int qulityIndex;

        Vector2 res;
        Resolution[] resolutions;

        private void Start()
        {
            SreceenSizeSetUP();
            //sound
            LoadSettings();
        }

        private void Update()
        {
            
            audioMixer.SetFloat(masterVolume, masterVolumeValue);            
        }

        public void SaveSettings()
        {
            PlayerPrefs.SetInt("Quality", qulityIndex);
            PlayerPrefs.SetInt("Res", resolutionIndex);
            PlayerPrefs.SetFloat("masterVolume", masterVolumeValue);
            Debug.Log("Saved settings" + qulityIndex + " res " + resolutionIndex);
        }

        public void LoadSettings()
        {
            masterVolumeSlider.value = PlayerPrefs.GetFloat("masterVolume");
            masterVolumeValue = PlayerPrefs.GetFloat("masterVolume");

            qulityIndex = PlayerPrefs.GetInt("Quality");
            qulityDropdown.value = PlayerPrefs.GetInt("Quality");
            resolutionIndex = PlayerPrefs.GetInt("Res");
            resolutionDropdown.value = PlayerPrefs.GetInt("Res");

            SetQuality(qulityIndex);
            SetResolution(resolutionIndex);
            Debug.Log("loaded Settings" + qulityIndex);
            
        }
        //video

        private void SreceenSizeSetUP()
        {
            resolutions = Screen.resolutions;

            resolutionDropdown.ClearOptions();

            List<string> options = new List<string>();

            int currentResolutionIndex = 0;

            for (int i = 0; i < resolutions.Length; i++)
            {
                string option = resolutions[i].width + "x" + resolutions[i].height;

                options.Add(option);

                if (resolutions[i].width == Screen.currentResolution.width &&
                    resolutions[i].height == Screen.currentResolution.height)
                {
                    currentResolutionIndex = i;
                }
            }

            resolutionDropdown.AddOptions(options);
            resolutionDropdown.value = currentResolutionIndex;
            resolutionDropdown.RefreshShownValue();
        }

        public void SetResolution(int resolutionIndex)
        {
            Debug.Log(resolutionIndex + "RES");
            this.resolutionIndex = resolutionIndex;
            Resolution resolution = resolutions[resolutionIndex];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
            res = new Vector2(resolution.width, resolution.height);
        }

        public void SetQuality(int graphicsIndex)
        {
            Debug.Log("Quality" + graphicsIndex);
            this.qulityIndex = graphicsIndex;
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
            masterVolumeValue = volume;
        }

        public float GetVolume()
        {
            return masterVolumeValue;
        }

        //controls

    }

}