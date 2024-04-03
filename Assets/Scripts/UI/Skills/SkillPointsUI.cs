using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using LostSouls.skill;



namespace LostSouls.UI.Skills
{
    public class SkillPointsUI : MonoBehaviour
    {
        [SerializeField] private SoulCollictor soulCollictor;
        [SerializeField] private TextMeshProUGUI pointsUI;


        private void Update()
        {
            pointsUI.text = soulCollictor.GetPonits().ToString();
        }


    }
}

