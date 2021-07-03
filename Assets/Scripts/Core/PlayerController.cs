using System;
using UnityEngine;

namespace Dodge.Core
{
    public class PlayerController : MonoBehaviour
    {
        public GameObject leftPlayerCube;
        public GameObject rightPlayerCube;

        public InputManager input;

        public float speed = 50f;
        public float gap = 5.2f;
        private float _leftCubeStartX;
        private float _rightCubeStartX;

        private void Start()
        {
            _leftCubeStartX = leftPlayerCube.transform.position.x;
            _rightCubeStartX = rightPlayerCube.transform.position.x;
        }

        private void Update()
        {
            switch (LeftPressed: input.IsLeftPressed, RightPressed: input.IsRightPressed)
            {
                case (true, true):
                    rightPlayerCube.transform.position = MoveTo(rightPlayerCube, _rightCubeStartX + gap);
                    leftPlayerCube.transform.position = MoveTo(leftPlayerCube, _leftCubeStartX - gap);
                    break;
                case (true, false):
                    rightPlayerCube.transform.position = MoveTo(rightPlayerCube, _rightCubeStartX - gap);
                    leftPlayerCube.transform.position = MoveTo(leftPlayerCube, _leftCubeStartX - gap);
                    break;
                case (false, true):
                    rightPlayerCube.transform.position = MoveTo(rightPlayerCube, _rightCubeStartX + gap);
                    leftPlayerCube.transform.position = MoveTo(leftPlayerCube, _leftCubeStartX + gap);
                    break;
                case (false, false):
                    rightPlayerCube.transform.position = MoveTo(rightPlayerCube, _rightCubeStartX);
                    leftPlayerCube.transform.position = MoveTo(leftPlayerCube, _leftCubeStartX);
                    break;
            }
        }

        private Vector3 MoveTo(GameObject cube, float toCord)
        {
            if (Math.Abs(cube.transform.position.x - toCord) < 0.1f)
                return cube.transform.position;

            return Vector3.MoveTowards(cube.transform.position, Vector3.right * toCord, speed * Time.deltaTime);
        }
    }
}