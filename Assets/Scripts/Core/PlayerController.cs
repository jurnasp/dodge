using System;
using UnityEngine;

namespace Dodge.Core
{
    public class PlayerController : MonoBehaviour
    {
        public GameObject playerCubeLeft;
        public GameObject playerCubeRight;

        public InputManager input;
        
        public float speed = 50f;
        public float border = 5.2f;
        private float _leftCubeStartX;
        private float _rightCubeStartX;

        public void Awake()
        {
            _leftCubeStartX = playerCubeLeft.transform.position.x;
            _rightCubeStartX = playerCubeRight.transform.position.x;
        }

        public void Update()
        {
            if (input.RightPressed && input.LeftPressed) {
                playerCubeRight.transform.position = MoveTo(playerCubeRight, _rightCubeStartX + border);
                playerCubeLeft.transform.position = MoveTo(playerCubeLeft, _leftCubeStartX - border);
            } else if (input.RightPressed) {
                playerCubeRight.transform.position = MoveTo(playerCubeRight, _rightCubeStartX + border);
                playerCubeLeft.transform.position = MoveTo(playerCubeLeft, _leftCubeStartX + border);
            } else if (input.LeftPressed) {
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
    }
}