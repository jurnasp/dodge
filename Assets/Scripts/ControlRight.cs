using UnityEngine;
using UnityEngine.Serialization;

//sama ControlLeft scriptiga

public class ControlRight : MonoBehaviour
{
    public GameObject right;
    public float speed = 50f;
    public float border = 5.2f;
    public float midBorder = 0.6f;
    public float odd = 1.2f;
    public Vector3 startPos;
    private bool _leftIsPressed;
    private bool _rightIsPressed;

    public void OnLeftButtonDown()
    {
        _leftIsPressed = true;
    }
    public void OnLeftButtonUp()
    {
        _leftIsPressed = false;
    }
    public void OnRightButtonDown()
    {
        _rightIsPressed = true;
    }
    public void OnRightButtonUp()
    {
        _rightIsPressed = false;
    }


    public void Start()
    {
        startPos = right.transform.position;
    }

    public void Update()
    {
        if (_rightIsPressed)
        {
            right.transform.Translate(speed*Time.deltaTime, 0, 0);
            if (right.transform.position.x > border)
            {
                transform.position = new Vector3(border, transform.position.y, transform.position.z);
            }
        }
        else if (right.transform.position.x > midBorder)
        {
            right.transform.position = Vector3.MoveTowards(right.transform.position, startPos, speed * Time.deltaTime);
        }

        if (_leftIsPressed)
        {
            right.transform.Translate(-speed * Time.deltaTime, 0, 0);
            if (right.transform.position.x < -border + odd)
            {
                transform.position = new Vector3(-border + odd, transform.position.y, transform.position.z);
            }
            if (_rightIsPressed)
            {
                right.transform.Translate(speed * Time.deltaTime, 0, 0);
                if (right.transform.position.x > border)
                {
                    transform.position = new Vector3(border, transform.position.y, transform.position.z);
                }
            }
        }
        else if (right.transform.position.x < midBorder)
        {
            right.transform.position = Vector3.MoveTowards(right.transform.position, startPos, speed * Time.deltaTime);
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