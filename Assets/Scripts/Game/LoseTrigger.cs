using Dodge.Enemy;
using UnityEngine;

namespace Dodge.Game
{
    public class LoseTrigger : MonoBehaviour
    {
        public bool lost;
        public GameObject startTrigger;
        private Obstacles _obstacles;

        private void Awake()
        {
            _obstacles = startTrigger.GetComponent<Obstacles>();
        }

        private void Update()
        {
            if (!_obstacles) lost = false;
        }

        private void OnCollisionEnter()
        {
            lost = true;
        }
    }
}