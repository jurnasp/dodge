using System;
using UnityEngine;

namespace Game
{
    public class CameraToAspectRatioFitter : MonoBehaviour
    {
        public StartingPosition cameraStartingPosition;
        private Camera _camera;

        public float edgeToEdgeLength = 18.26739f;
        public float screenOffsetFromPlayer = 1.5f;

        private void Awake()
        {
            _camera = GetComponent<Camera>();
        }

        private void Start()
        {
            _camera.transform.position = new Vector3(cameraStartingPosition.Position.x, CalculateCameraYFromAspectRatio(_camera.fieldOfView, _camera.aspect) - screenOffsetFromPlayer, CalculateCameraZFromAspectRatio(_camera.fieldOfView, _camera.aspect));
        }

        [ContextMenu("Fit")]
        public void Fit()
        {
            if(cameraStartingPosition == null || _camera == null) return;
            cameraStartingPosition.Position = new Vector3(cameraStartingPosition.Position.x, CalculateCameraYFromAspectRatio(_camera.fieldOfView, _camera.aspect) - screenOffsetFromPlayer, CalculateCameraZFromAspectRatio(_camera.fieldOfView, _camera.aspect));
        }

        private float CalculateCameraZFromAspectRatio(float fieldOfView, float newAspect)
        {
            var newHorizontalFOV = newAspect * fieldOfView;
            var newCameraToEdgeAngle = newHorizontalFOV / 2;
            var newCameraDistance = (edgeToEdgeLength / 2) / Mathf.Tan(Mathf.Deg2Rad * newCameraToEdgeAngle);

            return -newCameraDistance;
        }

        private float CalculateCameraYFromAspectRatio(float fieldOfView, float newAspect)
        {
            var newCameraZ = CalculateCameraZFromAspectRatio(fieldOfView, newAspect);
            var newY = Mathf.Tan((fieldOfView * Mathf.Deg2Rad) / 2) * newCameraZ;

            return -newY;
        }
    }
}