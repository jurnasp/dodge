using System.Linq;
using UnityEngine;

namespace Game
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform[] targets;
        public float smoothSpeed = 0.125f;
        public bool offsetByStartingPosition = true;
        
        private Vector3 _offset;

        private void Start()
        {
            if (offsetByStartingPosition) _offset = transform.position;
        }

        private void FixedUpdate()
        {
            var desiredPosition = GetTarget() + _offset;
            if (Vector3.Distance(transform.position, desiredPosition) > 0.01f)
            {
                var smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
                transform.position = smoothedPosition;
            }
            else
            {
                transform.position = desiredPosition;
            }
        }

        private Vector3 GetTarget()
        {
            var sum = new Vector3();
            sum = targets.Where(target => target).Aggregate(sum, (current, target) => current + target.position);
            sum /= targets.Length;
            return sum;
        }
    }
}