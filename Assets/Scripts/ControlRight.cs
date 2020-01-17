using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//sama ControlLeft scriptiga

public class ControlRight : MonoBehaviour
{
    public GameObject right;
    public float Speed = 50f;
    public float border = 5.2f;
    public float midborder = 0.6f;
    public float odd = 1.2f;
    public Vector3 startpos;
    private bool leftIsPressed = false;
    private bool rightIsPressed = false;

    public void OnLeftButtonDown()
    {
        leftIsPressed = true;
    }
    public void OnLeftButtonUp()
    {
        leftIsPressed = false;
    }
    public void OnRightButtonDown()
    {
        rightIsPressed = true;
    }
    public void OnRightButtonUp()
    {
        rightIsPressed = false;
    }


    public void Start()
    {
        startpos = right.transform.position;
    }

    public void Update()
    {
        if (rightIsPressed)
        {
            right.transform.Translate(Speed*Time.deltaTime, 0, 0);
            if (right.transform.position.x > border)
            {
                transform.position = new Vector3(border, transform.position.y, transform.position.z);
            }
        }
        else if (right.transform.position.x > midborder)
        {
            right.transform.position = Vector3.MoveTowards(right.transform.position, startpos, Speed * Time.deltaTime);
        }

        if (leftIsPressed)
        {
            right.transform.Translate(-Speed * Time.deltaTime, 0, 0);
            if (right.transform.position.x < -border + odd)
            {
                transform.position = new Vector3(-border + odd, transform.position.y, transform.position.z);
            }
            if (rightIsPressed)
            {
                right.transform.Translate(Speed * Time.deltaTime, 0, 0);
                if (right.transform.position.x > border)
                {
                    transform.position = new Vector3(border, transform.position.y, transform.position.z);
                }
            }
        }
        else if (right.transform.position.x < midborder)
        {
            right.transform.position = Vector3.MoveTowards(right.transform.position, startpos, Speed * Time.deltaTime);
        }
    }
}
/*
public void Update()                                //See on algne kood, et arvutiga töötaks
{
    if (Input.GetMouseButton(1))
    {
        right.transform.Translate(Speed * Time.deltaTime, 0, 0);
        if (right.transform.position.x > border)
        {
            transform.position = new Vector3(border, transform.position.y, transform.position.z);
        }
    }

    else if (right.transform.position.x > midborder)
    {
        right.transform.position = Vector3.MoveTowards(right.transform.position, startpos, Speed * Time.deltaTime);
    }


    if (Input.GetMouseButton(0))
    {
        right.transform.Translate(-Speed * Time.deltaTime, 0, 0);
        if (right.transform.position.x < -border + odd)
        {
            transform.position = new Vector3(-border + odd, transform.position.y, transform.position.z);
        }
        if (Input.GetMouseButton(1))
        {
            right.transform.Translate(Speed * Time.deltaTime, 0, 0);
            if (right.transform.position.x > border)
            {
                transform.position = new Vector3(border, transform.position.y, transform.position.z);
            }
        }
    }

    else if (right.transform.position.x < midborder)
    {
        right.transform.position = Vector3.MoveTowards(right.transform.position, startpos, Speed * Time.deltaTime);
    }
}
}
*/