using System;
using UnityEngine;

namespace Dodge.Core
{
    public class PlayerController : MonoBehaviour
    {
        public GameObject playerCubeLeft;
        public GameObject playerCubeRight;
        public float speed = 50f;
        public float border = 5.2f;
        private bool _leftPressed;
        private bool _rightPressed;
        private float _leftCubeStartX;
        private float _rightCubeStartX;

        public void OnLeftButtonDown()
        {
            _leftPressed = true;
        }
        public void OnLeftButtonUp()
        {
            _leftPressed = false;
        }
        public void OnRightButtonDown()
        {
            _rightPressed = true;
        }
        public void OnRightButtonUp()
        {
            _rightPressed = false;
        }

        public void Awake()
        {
            _leftCubeStartX = playerCubeLeft.transform.position.x;
            _rightCubeStartX = playerCubeRight.transform.position.x;
        }

        public void Update()
        {
            ArrowControls();
            if (_rightPressed && _leftPressed) {
                playerCubeRight.transform.position = MoveTo(playerCubeRight, _rightCubeStartX + border);
                playerCubeLeft.transform.position = MoveTo(playerCubeLeft, _leftCubeStartX - border);
            } else if (_rightPressed) {
                playerCubeRight.transform.position = MoveTo(playerCubeRight, _rightCubeStartX + border);
                playerCubeLeft.transform.position = MoveTo(playerCubeLeft, _leftCubeStartX + border);
            } else if (_leftPressed) {
                playerCubeRight.transform.position = MoveTo(playerCubeRight, _rightCubeStartX - border);
                playerCubeLeft.transform.position = MoveTo(playerCubeLeft, _leftCubeStartX - border);
            } else {
                playerCubeRight.transform.position = MoveTo(playerCubeRight, _rightCubeStartX);
                playerCubeLeft.transform.position = MoveTo(playerCubeLeft, _leftCubeStartX);
            }
        }

        private Vector3 MoveTo(GameObject cube, float toCord)
        {
            if(Math.Abs(cube.transform.position.x - toCord) < 0.1f)
                return cube.transform.position;
        
            return Vector3.MoveTowards(cube.transform.position,Vector3.right * toCord, speed * Time.deltaTime);
        }

        private void ArrowControls()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                OnLeftButtonDown();
            }
            if(Input.GetKeyUp(KeyCode.LeftArrow))
            {
                OnLeftButtonUp();
            }
            if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                OnRightButtonDown();
            }
            if(Input.GetKeyUp(KeyCode.RightArrow))
            {
                OnRightButtonUp();
            }
        }
    }
}