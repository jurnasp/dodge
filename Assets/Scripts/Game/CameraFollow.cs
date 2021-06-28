using System.Linq;
using UnityEngine;

namespace Dodge.Game
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
            var smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }

        private Vector3 GetTarget()
        {
            var sum = new Vector3();
            sum = targets.Aggregate(sum, (current, target) => current + target.position);
            sum /= targets.Length;
            return sum;
        }
    }
}