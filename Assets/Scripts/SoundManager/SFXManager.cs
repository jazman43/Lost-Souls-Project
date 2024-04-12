using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LostSouls.SoundManager
{

    public class SFXManager : MonoBehaviour
    {
        [SerializeField] AudioSource sfxAudioSource;

        [SerializeField] List<SFXSoundData> sfxSoundDatas;

        public float masterVolume = 1;
        public float sfxMasterVolume = 1;

        public static SFXManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        //call where you want it to play
        public void PlaySFX(SFXSoundData.SFX sfx)
        {
            SFXSoundData data = sfxSoundDatas.Find(data => data.sfx == sfx);
            sfxAudioSource.volume = data.volume * sfxMasterVolume * masterVolume;
            sfxAudioSource.PlayOneShot(data.audioClip);
        }

    }


    [System.Serializable]
    public class SFXSoundData
    {
        public enum SFX
        {
            Attack,
            Damage,
            Appear,
            Walk,
            Healing,
            SoulOrbs,


        }

        public SFX sfx;
        public AudioClip audioClip;
        [Range(0, 1)]
        public float volume = 1;
    }
}
