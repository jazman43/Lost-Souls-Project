using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using LostSouls.combat;


namespace LostSouls.UI
{
    public class HealthUI : MonoBehaviour
    {
        


        [SerializeField] private UnityEngine.UI.Slider healthUI = null;
        [SerializeField] private Health health;

        
       

        private void Update()
        {
            
            healthUI.value = health.GetPlayerHealth();
            healthUI.maxValue = health.GetMaxPlayerHealth();
        }
    }

}