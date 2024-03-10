using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnemyBGM : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.PlayBGM(BGMSoundData.BGM.Dungeon);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
