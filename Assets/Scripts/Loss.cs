using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loss : MonoBehaviour
{
    public bool lost = false;
    public GameObject startTrigger;

    private void OnCollisionEnter(Collision collision)  //kui miski objekti puudutab siis...
    {
        lost = true;                                    //annab teada, et mäng on kaotatud
    }

    public void Update()
    {
        if (!startTrigger.GetComponent<Obstacles>())    //kui mäng algas uuesti siis...
        {
            lost = false;                               //muudab kaotuse muutuja uuesti vääriks(siis ei saada teistele, et mäng on kaotatud)
        }                                               //ja saab mäng uuesti alata
    }
}
