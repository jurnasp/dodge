using System;
using UnityEngine;

namespace Core
{
    public class PlayerController : MonoBehaviour
    {
        public GameObject leftPlayerCube;
        public GameObject rightPlayerCube;

        public InputManager input;

        public float speed = 50f;
        public float edge = 5.2f;
        private float _leftCubeStartX;
        private float _rightCubeStartX;
        private bool _stop;

        private void Start()
        {
            _leftCubeStartX = leftPlayerCube.transform.position.x;
            _rightCubeStartX = rightPlayerCube.transform.position.x;
        }

        private void Update()
        {
            if (_stop) return;
            
            switch (input.IsLeftPressed, input.IsRightPressed)
            {
                case (true, true):
                    rightPlayerCube.transform.position = MoveTo(rightPlayerCube, _rightCubeStartX + edge);
                    leftPlayerCube.transform.position = MoveTo(leftPlayerCube, _leftCubeStartX - edge);
                    break;
                case (true, false):
                    rightPlayerCube.transform.position = MoveTo(rightPlayerCube, _rightCubeStartX - edge);
                    leftPlayerCube.transform.position = MoveTo(leftPlayerCube, _leftCubeStartX - edge);
                    break;
                case (false, true):
                    rightPlayerCube.transform.position = MoveTo(rightPlayerCube, _rightCubeStartX + edge);
                    leftPlayerCube.transform.position = MoveTo(leftPlayerCube, _leftCubeStartX + edge);
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

        public void GameEnd()
        {
            _stop = true;
        }
    }
}