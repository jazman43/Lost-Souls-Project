using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LostSouls.skill
{
    
    public interface ISkill 
    {
        string Name { get; }
        bool isUnlocked { get; set; }
        void ApplySkill(GameObject player);
    }
}
