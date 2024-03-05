using UnityEngine;

namespace Game
{
    public class Configuration : MonoBehaviour
    {
        private void Start()
        {
            SetVsync0_60FPS();
        }

        private static void SetVsync0_60FPS()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate =  60;
        }
    }
}