using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//controlLeft ja controlRight on täpselt vastanduvad üksteisele.

public class ControlLeft : MonoBehaviour
{
    public GameObject left;
    public GameObject right;
    public float Speed = 50f;
    public float border = 5.2f;
    public float midborder = -0.6f;
    public float odd = 1.2f;
    public Vector3 startpos;
    public bool leftIsPressed = false;
    public bool rightIsPressed = false;

    public void OnLeftButtonDown()
    {
        leftIsPressed = true; // kui vasakut ekraani pool vajutada siis annab teada, et see on all vajutatud. alumistega on täselt sama
    }
    public void OnLeftButtonUp()
    {
        leftIsPressed = false; // kui nupp üleval siis annab samamoodi vastuse aga teistsuguse
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
        startpos = left.transform.position;
    }

    public void Update()
    {
        if (left.transform.position.x > right.transform.position.x - odd)//määrab vahe millest, üle ei saa minna, muidu on võimalik et üks läheb teise sisse
        {
            left.transform.position = new Vector3(right.transform.position.x - odd, left.transform.position.y, left.transform.position.z);
        }

        if (leftIsPressed)//kui vasakule ekraani poolele vajutada siis...
        {
            left.transform.Translate(-Speed * Time.deltaTime, 0, 0);    //liigub vasakule ja...
            if (left.transform.position.x < -border)                    //kui liikumise tagajärjel jõudis vasaku ekraani äärele siis...
            {
                transform.position = new Vector3(-border, transform.position.y, transform.position.z);     //ei lase üle ääre minna
            }
        }
        else if (left.transform.position.x < midborder)     //ja kui pole midagi vajutatud siis ja näeb et pole keskel siis...
        {
            left.transform.position = Vector3.MoveTowards(left.transform.position, startpos, Speed * Time.deltaTime);// hakkab kesmise poole liikuma
        }

        if (rightIsPressed)//kui parem pool ekraani on vajutatud siis...
        {
            left.transform.Translate(Speed * Time.deltaTime, 0, 0); // hakkab paremale liikuma
            if (left.transform.position.x > border - odd)           //kui samal ajal liikudes jõuab paremale ekraani äärde siis...
            {
                transform.position = new Vector3(border - odd, transform.position.y, transform.position.z); //ei lase üle ekraani ääre
            }
            if (leftIsPressed)//kui parema ekraani poolega koos on vasak ka vajutatud siis...
            {
                left.transform.Translate(-Speed * Time.deltaTime, 0, 0);//hakkab vasak vasakule liikuma
                if (left.transform.position.x < -border)                //kui vasak jõuab vasakule ekraani äärele siis...
                {
                    transform.position = new Vector3(-border, transform.position.y, transform.position.z);//ei lase üle ääre
                }
            }
        }
        else if (left.transform.position.x > midborder)
        {
            left.transform.position = Vector3.MoveTowards(left.transform.position, startpos, Speed * Time.deltaTime);
        }
    }
}
/*
public void Update()
{
    if (Input.GetMouseButton(0))//if lmb then move left
    {
        left.transform.Translate(-Speed * Time.deltaTime, 0, 0);
        if (left.transform.position.x < -border)
        {
            transform.position = new Vector3(-border, transform.position.y, transform.position.z);
        }
    }

    else if (left.transform.position.x < midborder)
    {
        left.transform.position = Vector3.MoveTowards(left.transform.position, startpos, Speed * Time.deltaTime);
    }


    if (Input.GetMouseButton(1))//if rmb then move right
    {
        left.transform.Translate(Speed * Time.deltaTime, 0, 0);
        if (left.transform.position.x > border - odd)
        {
            transform.position = new Vector3(border - odd, transform.position.y, transform.position.z);
        }
        if (Input.GetMouseButton(0))//if both clicked
        {
            left.transform.Translate(-Speed * Time.deltaTime, 0, 0);
            if (left.transform.position.x < -border)
            {
                transform.position = new Vector3(-border, transform.position.y, transform.position.z);
            }
        }
    }

    else if (left.transform.position.x > midborder)
    {
        left.transform.position = Vector3.MoveTowards(left.transform.position, startpos, Speed * Time.deltaTime);
    }
}
*/