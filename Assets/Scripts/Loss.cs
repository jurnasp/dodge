using UnityEngine;

public class Loss : MonoBehaviour
{
    public bool lost = false;
    public GameObject startTrigger;
    private Obstacles _obstacles;

    private void Start()
    {
        _obstacles = startTrigger.GetComponent<Obstacles>();
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
