using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LostSouls.SoundManager;

namespace LostSouls.DungeonBGM
{

    public class DungeonBGM : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            BGMManager.Instance.PlayBGM(BGMSoundData.BGM.Dungeon);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
