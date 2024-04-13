using System.Collections;
using System.Collections.Generic;
using LostSouls.SoundManager;
using UnityEngine;


namespace LostSouls.BattleBGM
{

    public class BattleBGM : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            BGMManager.Instance.PlayBGM(BGMSoundData.BGM.Battle);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}