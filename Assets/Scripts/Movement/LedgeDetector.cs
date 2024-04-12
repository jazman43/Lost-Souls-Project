using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace LostSouls.Movement
{
    public class LedgeDetector : MonoBehaviour
    {
        public event Action<Vector3> OnLedgeDetect;

        //private bool isHitLedge;

       

        private void OnTriggerEnter(Collider other)
        {
                       
            OnLedgeDetect?.Invoke( other.transform.forward);
        }

        
    }
}

