using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

namespace LostSouls.SoundManager
{
    public class AudioManager : MonoBehaviour
    {        
        void Start()
        {
            CheckIfCanPlay();
        }




        private void CheckIfCanPlay()
        {
            //check if we are in main menu or main game
            if(SceneManager.GetSceneByBuildIndex(0) == SceneManager.GetActiveScene())
            {
                //main menu
                BGMManager.Instance.PlayBGM(BGMSoundData.BGM.MainMenu);
            }
            else
            {
                BGMManager.Instance.PlayBGM(BGMSoundData.BGM.game_loop);
            }
        }
        //TO DO set up different BGM's to start and stop in correct places 
    }
}
