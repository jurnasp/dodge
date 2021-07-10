using UnityEngine;

namespace Core
{
    public class InputManager : MonoBehaviour
    {
        public bool IsLeftPressed { get; private set; }

        public bool IsRightPressed { get; private set; }

        private void Update()
        {
            ArrowControls();
        }

        public void OnLeftButtonDown()
        {
            IsLeftPressed = true;
        }

        public void OnLeftButtonUp()
        {
            IsLeftPressed = false;
        }

        public void OnRightButtonDown()
        {
            IsRightPressed = true;
        }

        public void OnRightButtonUp()
        {
            IsRightPressed = false;
        }

        private void ArrowControls()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow)) OnLeftButtonDown();
            if (Input.GetKeyDown(KeyCode.RightArrow)) OnRightButtonDown();

            if (Input.GetKeyUp(KeyCode.LeftArrow)) OnLeftButtonUp();
            if (Input.GetKeyUp(KeyCode.RightArrow)) OnRightButtonUp();
        }
    }
}