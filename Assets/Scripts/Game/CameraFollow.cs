using System.Linq;
using UnityEngine;

namespace Game
{
    public class CameraFollow : MonoBehaviour
    {
        public StartingPosition cameraStartingPosition;
        public Transform[] targets;
        public float smoothSpeed = 0.125f;
        public bool offsetByStartingPosition = true;
        
        private Vector3 _offset;

        private void FixedUpdate()
        {
            if (offsetByStartingPosition) _offset = cameraStartingPosition.Position;
            var desiredPosition = GetTargetAveragePosition() + _offset;
            var currentPosition = transform.position;
            
            Vector3 newPosition = desiredPosition;
            if (Vector3.Distance(currentPosition, desiredPosition) > 0.01f)
            {
                var smoothedPosition = Vector3.Lerp(currentPosition, desiredPosition, smoothSpeed);
                newPosition = smoothedPosition;
            }

            transform.position = newPosition;
        }

        private Vector3 GetTargetAveragePosition()
        {
            var sum = new Vector3();
            sum = targets.Where(target => target).Aggregate(sum, (current, target) => current + target.position);
            sum /= targets.Length;
            return sum;
        }
    }
}