using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD:Assets/Scripts/SoundManager/BattleBGM.cs
namespace LostSouls.DungeonBGM
{

    public class DungeonBGM : MonoBehaviour
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
=======

namespace LostSouls.SoundManager
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
>>>>>>> 11393002072460163574c34820309485021264ab:Assets/Scripts/SoundManager/DungeonBGM.cs
}
