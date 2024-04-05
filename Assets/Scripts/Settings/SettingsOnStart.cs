using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace LostSouls.setting
{
    public class SettingsOnStart : MonoBehaviour
    {
        [SerializeField] private string masterVolume = "MasterVolume";
        [SerializeField] private string sfxVolume = "SFX Volume";

        [SerializeField] private AudioMixer audioMixer;
        [SerializeField] private LostSouls.UI.Menus.Settings settings;

        void Start()
        {
            settings.LoadSettings();
        }

        
        void Update()
        {            
            //PlayerPrefs.SetFloat("masterVolume", settings.GetVolume());
        }
    }
}

