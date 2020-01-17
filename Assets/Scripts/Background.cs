using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {
    public Rigidbody cube;
    public float speed = -1f;
    public float posX;
    public float startTime;
    public float addTime = 0.1f;
    public float targetY = -70f;
    public float destroyTime = 4f;
    public float range = 5f;

    public void Update()
    {
        if(startTime < Time.time)
        {
            startTime = Time.time;
            Rigidbody clone = Instantiate(cube, new Vector3(transform.position.x + posX, transform.position.y, transform.position.z), Random.rotation) as Rigidbody;
            clone.velocity = (new Vector3(clone.transform.position.x, clone.transform.position.y - targetY, clone.transform.position.z) - clone.transform.position) * speed;
            posX = Random.Range(-range, range);
            startTime = Time.time + addTime;
            Destroy(clone.gameObject, destroyTime);
        }
    }
}
