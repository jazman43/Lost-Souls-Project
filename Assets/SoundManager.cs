using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource bgmAudioSource;
    [SerializeField] AudioSource sfxAudioSource;

    [SerializeField] List<BGMSoundData> bgmSoundDatas;
    [SerializeField] List<SFXSoundData> sfxSoundDatas;

    public float masterVolume = 1;
    public float bgmMasterVolume = 1;
    public float sfxMasterVolume = 1;

    public static SoundManager Instance { get; private set; }

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


    public void PlaySFX(SFXSoundData.SFX sfx)
    {
        SFXSoundData data = sfxSoundDatas.Find(data => data.sfx == sfx);
        sfxAudioSource.volume = data.volume * sfxMasterVolume * masterVolume;
        sfxAudioSource.PlayOneShot(data.audioClip);
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
        Restart,
        game_loop,
    }

    public BGM bgm;
    public AudioClip audioClip;
    [Range(0, 1)]
    public float volume = 1;
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

    }

    public SFX sfx;
    public AudioClip audioClip;
    [Range(0, 1)]
    public float volume = 1;
}
