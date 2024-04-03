using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



namespace LostSouls.combat
{
    [Serializable]
    public class Attack 
    {
        [field: SerializeField] public string AnimationName { get; private set; }

        [field: SerializeField] public float TransitionTime { get; private set; } = 0.1f;
        

        [field: SerializeField] public int ComboStateIndex { get; private set; } = -1;
        [field: SerializeField] public int LastComboIndex { get; private set; } = 2;
        [field: SerializeField] public float ComboAttackTime { get; private set; }
        [field: SerializeField] public float ForceTime { get; private set; }
        [field: SerializeField] public float Force { get; private set; }
        [field: SerializeField] public float Damage { get; private set; }
    }
}
