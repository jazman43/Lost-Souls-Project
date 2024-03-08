using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;



namespace LostSouls.Camera
{
    public class MoveMenuCam : MonoBehaviour
    {
        [SerializeField] private float camMoveSpeed = 1f;
        [SerializeField] private CinemachineVirtualCamera virtualCamera;
        private CinemachineTrackedDolly trackedDolly;


        private void Awake()
        {
            trackedDolly = virtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
        }


        private void Update()
        {
            if(trackedDolly.m_PathPosition >= 1)
            {
                trackedDolly.m_PathPosition = 0;
            }
            else
            {
                trackedDolly.m_PathPosition += camMoveSpeed * Time.deltaTime;
            }

            
        }
    }
}
