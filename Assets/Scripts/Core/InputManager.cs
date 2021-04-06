using System;
using UnityEngine;

namespace Dodge.Core
{
    public class InputManager : MonoBehaviour
    {
        public bool LeftPressed { get ; private set; }

        public bool RightPressed { get ; private set; }

        public void Update()
        {
            ArrowControls();
        }

        public void OnLeftButtonDown()
        {
            LeftPressed = true;
        }
        public void OnLeftButtonUp()
        {
            LeftPressed = false;
        }
        public void OnRightButtonDown()
        {
            RightPressed = true;
        }
        public void OnRightButtonUp()
        {
            RightPressed = false;
        }
        
        private void ArrowControls()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                OnLeftButtonDown();
            }
            if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                OnRightButtonDown();
            }
            
            if(Input.GetKeyUp(KeyCode.LeftArrow))
            {
                OnLeftButtonUp();
            }
            if(Input.GetKeyUp(KeyCode.RightArrow))
            {
                OnRightButtonUp();
            }
        }
        
    }
}