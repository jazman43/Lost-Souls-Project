using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace LostSouls.Movement
{
    public class WallDetector : MonoBehaviour
    {
        public event Action<Vector3> OnWallDetect;
        public event Action OnWallLeave;


        private void OnTriggerExit(Collider other)
        {
            OnWallLeave?.Invoke();
        }

        private void OnTriggerEnter(Collider other)
        {

            OnWallDetect?.Invoke(other.transform.forward);
        }
    }
}
