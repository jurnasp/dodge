using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class EnemyCreator : MonoBehaviour
{
    public List<GameObject> enemyPrefabs;
    
    // @Todo Rename all of these
    private float _speed = 15f;
    private float speedAdd_ = 4f;
    private float _addTime = 1.25f;
    private float _pause = 2.5f;

    private float _timer;
    private Random _random;

    public void Start()
    {
        _timer = Time.time;
        _random = new Random();
    }

    public void Update()
    {
        if (Time.time > _timer + _pause)
        {
            _timer = Time.time;

            var index = _random.Next(enemyPrefabs.Count);
            var go = Instantiate(enemyPrefabs[index], transform.position, enemyPrefabs[index].transform.rotation);

            EnemyMove em = go.GetComponent<EnemyMove>();

            em.speed = _speed;
            em.toY = -5;
        }
    }
}
