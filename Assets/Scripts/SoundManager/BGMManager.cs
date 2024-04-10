using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LostSouls.SoundManager
{

    public class BGMManager : MonoBehaviour
    {
        [SerializeField] AudioSource bgmAudioSource;

        [SerializeField] List<BGMSoundData> bgmSoundDatas;

        public float masterVolume = 1;
        public float bgmMasterVolume = 1;

        public static BGMManager Instance { get; private set; }

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

        public void PlayBGM(BGMSoundData.BGM bgm)
        {
            BGMSoundData data = bgmSoundDatas.Find(data => data.bgm == bgm);
            bgmAudioSource.clip = data.audioClip;
            bgmAudioSource.volume = data.volume * bgmMasterVolume * masterVolume;
            bgmAudioSource.Play();
        }

    }

    [System.Serializable]
    public class BGMSoundData
    {
        public enum BGM
        {
            Title,
            Dungeon,
            MainMenu,
            GameOver,
            Battle,
            game_loop,
        }

        public BGM bgm;
        public AudioClip audioClip;
        [Range(0, 1)]
        public float volume = 1;
    }
}
