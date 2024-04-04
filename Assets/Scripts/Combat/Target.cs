using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;



namespace LostSouls.combat
{
    public class Target : MonoBehaviour
    {
        public event Action<Target> OnDestroyed;

        private void OnDestroy()
        {
            OnDestroyed?.Invoke(this);
        }
    }

}