using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


namespace LostSouls.Camera
{
    public class ChangeLookAT : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera virtualCamera;
        [SerializeField] private string swapCam = "camSawp";
        [SerializeField] private GameObject lookAtlake;
        [SerializeField] private GameObject lookAtHill;


        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == swapCam)
            {
                virtualCamera.m_LookAt = lookAtHill.transform;
                Debug.Log("hit");
            }
            
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == swapCam)
            {
                virtualCamera.m_LookAt = lookAtlake.transform;
            }
           
        }
    }
}
