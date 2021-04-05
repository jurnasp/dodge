using UnityEngine;

public class LoseTrigger : MonoBehaviour
{
    public bool lost;
    public GameObject startTrigger;
    private Enemy.Obstacles _obstacles;

    private void Start()
    {
        _obstacles = startTrigger.GetComponent<Enemy.Obstacles>();
    }

    private void OnCollisionEnter()
    {
        lost = true;
    }

    public void Update()
    {
        if (!_obstacles)
        {
            lost = false;
        }
    }
}
