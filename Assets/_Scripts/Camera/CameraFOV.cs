using System;
using Cinemachine;
using UnityEngine;

namespace _Scripts.Camera
{
    public class CameraFOV : MonoBehaviour
    {
        public CinemachineVirtualCamera _virtualCamera;


        public float _targetFOV;

        private void Start()
        {
            _virtualCamera = GetComponent<CinemachineVirtualCamera>();
            _targetFOV = _virtualCamera.m_Lens.FieldOfView;
        }


        private void OnEnable()
        {
            HoleEvent.OnLevelUp += UpdateFOV;
        }

        private void OnDisable()
        {
            HoleEvent.OnLevelUp -= UpdateFOV;
        }


        private void FixedUpdate()
        {
            _virtualCamera.m_Lens.FieldOfView =
                Mathf.Lerp(_virtualCamera.m_Lens.FieldOfView, _targetFOV, Time.deltaTime);
        }

        private void UpdateFOV() 
        {
            // Change FOV of Camera;
            _targetFOV*= 1.1f;
           
        }
    }
}