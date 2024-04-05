using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


namespace LostSouls.SoundManager
{
    public class AudioManager : MonoBehaviour
    {        
        void Start()
        {
            BGMManager.Instance.PlayBGM(BGMSoundData.BGM.MainMenu);
        }


        private void Update()
        {
            BGMManager.Instance.GetAudioMixer().GetFloat("masterVolume", )
        }
    }
}
