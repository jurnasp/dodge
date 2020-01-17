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

    private void OnCollisionEnter()  //kui miski objekti puudutab siis...
    {
        lost = true;                                    //annab teada, et mäng on kaotatud
    }

    public void Update()
    {
        if (!_obstacles)    //kui mäng algas uuesti siis...
        {
            lost = false;                               //muudab kaotuse muutuja uuesti vääriks(siis ei saada teistele, et mäng on kaotatud)
        }                                               //ja saab mäng uuesti alata
    }
}
