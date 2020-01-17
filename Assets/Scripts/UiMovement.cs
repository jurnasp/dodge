using UnityEngine;

public class UiMovement : MonoBehaviour
{
    public GameObject camerapos;
    public GameObject left;

    ControlLeft button;

    public float step;
    public float startTime;
    public float journeyLength = 0.6f;//0.6f
    public float speed = 0.6f; // 0.6f
    public float fractJourney;

    private bool startLScreen = false;
    private bool startRScreen = false;


    public void Start()
    {
        button = left.GetComponent<ControlLeft>();
        //journeyLenght = -1f;// Vector3.Distance(camerapos.transform.position, new Vector3(-1f, 10, -20));
    }
    public void Update()
    {
        if (button.leftIsPressed)
        {
            if (button.rightIsPressed)
            {
                if (!startRScreen | !startLScreen)
                {
                    startTime = Time.time;
                    fractJourney = 0f;
                    startRScreen = true;
                    startLScreen = true;
                }
                float distanceCovered = (Time.time - startTime) * speed;
                fractJourney = distanceCovered / journeyLength;
                camerapos.transform.position = Vector3.Lerp(camerapos.transform.position, new Vector3(0, 10, -20), fractJourney);
            }
            else if (!button.rightIsPressed)
            {
                if (startLScreen)
                {
                    startTime = Time.time;
                    fractJourney = 0f;
                    startLScreen = false;
                }
                float distanceCovered = (Time.time - startTime) * speed;
                fractJourney = distanceCovered / journeyLength;
                camerapos.transform.position = Vector3.Lerp(camerapos.transform.position, new Vector3(-(journeyLength), 10, -20), fractJourney);
            }
        }
        if (button.rightIsPressed)
        {
            if (!button.leftIsPressed)
            {
                if (startRScreen)
                {
                    startTime = Time.time;
                    fractJourney = 0f;
                    startRScreen = false;
                }
                float distanceCovered = (Time.time - startTime) * speed;
                fractJourney = distanceCovered / journeyLength;
                camerapos.transform.position = Vector3.Lerp(camerapos.transform.position, new Vector3(journeyLength, 10, -20), fractJourney);
            }
        }
        if (!button.rightIsPressed & !button.leftIsPressed)
        {
            if (!startRScreen | !startLScreen)
            {
                startTime = Time.time;
                fractJourney = 0f;
                startRScreen = true;
                startLScreen = true;
            }
            float distanceCovered = (Time.time - startTime) * speed;
            fractJourney = distanceCovered / journeyLength;
            camerapos.transform.position = Vector3.Lerp(camerapos.transform.position, new Vector3(0, 10, -20), fractJourney);
        }
    }

    /*
     
    public GameObject camerapos;
    public GameObject sideBars;
    public GameObject scoretext;
    public GameObject left;

    ControlLeft button;

    public float step;
    public float startTime;
    public float journeyLenght = 0.6f;//0.6f
    public float speed = 0.6f; // 0.6f
    public float barspeed = 0.6f; // 50f
    public float barJourneyLenght = 0.6f; //50
    public float fractJourney;
    public float barfractJourney;

    private bool startLScreen = false;
    private bool startRScreen = false;


    public void Start()
    {
        button = left.GetComponent<ControlLeft>();
        //journeyLenght = -1f;// Vector3.Distance(camerapos.transform.position, new Vector3(-1f, 10, -20));
    }
    public void Update()
    {
        if (button.leftIsPressed)
        {
            if (button.rightIsPressed)
            {
                if (!startRScreen | !startLScreen)
                {
                    startTime = Time.time;
                    fractJourney = 0f;
                    barfractJourney = 0f;
                    startRScreen = true;
                    startLScreen = true;
                }
                float distanceCovered = (Time.time - startTime) * speed;
                fractJourney = distanceCovered / journeyLenght;
                float bardistanceCovered = (Time.time - startTime) * barspeed;
                barfractJourney = bardistanceCovered / barJourneyLenght;
                camerapos.transform.position = Vector3.Lerp(camerapos.transform.position, new Vector3(0, 10, -20), fractJourney);
                sideBars.transform.position = Vector3.Lerp(sideBars.transform.position, new Vector3(0, 0, 0), barfractJourney);
            }
            else if (!button.rightIsPressed)
            {
                if (startLScreen)
                {
                    startTime = Time.time;
                    fractJourney = 0f;
                    barfractJourney = 0f;
                    startLScreen = false;
                }
                float distanceCovered = (Time.time - startTime) * speed;
                fractJourney = distanceCovered / journeyLenght;
                float bardistanceCovered = (Time.time - startTime) * barspeed;
                barfractJourney = bardistanceCovered / barJourneyLenght;
                camerapos.transform.position = Vector3.Lerp(camerapos.transform.position, new Vector3(-(journeyLenght), 10, -20), fractJourney);
                sideBars.transform.position = Vector3.Lerp(sideBars.transform.position, new Vector3(barJourneyLenght, 0, 0), barfractJourney);
            }
        }
        if (button.rightIsPressed)
        {
            if (!button.leftIsPressed)
            {
                if (startRScreen)
                {
                    startTime = Time.time;
                    fractJourney = 0f;
                    barfractJourney = 0f;
                    startRScreen = false;
                }
                float distanceCovered = (Time.time - startTime) * speed;
                fractJourney = distanceCovered / journeyLenght;
                float bardistanceCovered = (Time.time - startTime) * barspeed;
                barfractJourney = bardistanceCovered / barJourneyLenght;
                camerapos.transform.position = Vector3.Lerp(camerapos.transform.position, new Vector3(journeyLenght, 10, -20), fractJourney);
                sideBars.transform.position = Vector3.Lerp(sideBars.transform.position, new Vector3(-barJourneyLenght, 0, 0), barfractJourney);
            }
        }
        if (!button.rightIsPressed & !button.leftIsPressed)
        {
            if (!startRScreen | !startLScreen)
            {
                startTime = Time.time;
                fractJourney = 0f;
                barfractJourney = 0f;
                startRScreen = true;
                startLScreen = true;
            }
            float distanceCovered = (Time.time - startTime) * speed;
            fractJourney = distanceCovered / journeyLenght;
            float bardistanceCovered = (Time.time - startTime) * barspeed;
            barfractJourney = bardistanceCovered / barJourneyLenght;
            camerapos.transform.position = Vector3.Lerp(camerapos.transform.position, new Vector3(0, 10, -20), fractJourney);
            sideBars.transform.position = Vector3.Lerp(sideBars.transform.position, new Vector3(0, 0, 0), barfractJourney);
        }
    }

     */
    /*
    public GameObject camerapos;
    public GameObject sideBars;
    public GameObject scoretext;
    public GameObject left;

    ControlLeft button;

    public float step;
    public float startTime;
    public float journeyLenght = 0.3f;// = 0.2f;//0.5f(19.03.2018)//1.5
    public float speed = 0.3f;
    public float barspeed = 50f;
    public float barJourneyLenght = 50;
    public float fractJourney;
    public float barfractJourney;

    private bool startLScreen = false;
    private bool startRScreen = false;


    public void Start()
    {
        button = left.GetComponent<ControlLeft>();
        //journeyLenght = -1f;// Vector3.Distance(camerapos.transform.position, new Vector3(-1f, 10, -20));
    }
    public void Update()
    {
        if (button.leftIsPressed)
        {
            if (button.rightIsPressed)
            {
                if (!startRScreen | !startLScreen)
                {
                    startTime = Time.time;
                    fractJourney = 0f;
                    barfractJourney = 0f;
                    startRScreen = true;
                    startLScreen = true;
                }
                float distanceCovered = (Time.time - startTime) * speed;
                fractJourney = distanceCovered / journeyLenght;
                float bardistanceCovered = (Time.time - startTime) * barspeed;
                barfractJourney = bardistanceCovered / barJourneyLenght;
                camerapos.transform.position = Vector3.Lerp(camerapos.transform.position, new Vector3(0, 10, -20), fractJourney);
                sideBars.transform.position = Vector2.Lerp(sideBars.transform.position, new Vector2(0, 0), barfractJourney);
            }
            else if (!button.rightIsPressed)
            {
                if (startLScreen)
                {
                    startTime = Time.time;
                    fractJourney = 0f;
                    barfractJourney = 0f;
                    startLScreen = false;
                }
                float distanceCovered = (Time.time - startTime) * speed;
                fractJourney = distanceCovered / journeyLenght;
                float bardistanceCovered = (Time.time - startTime) * barspeed;
                barfractJourney = bardistanceCovered / barJourneyLenght;
                camerapos.transform.position = Vector3.Lerp(camerapos.transform.position, new Vector3(-(journeyLenght), 10, -20), fractJourney);
                sideBars.transform.position = Vector2.Lerp(sideBars.transform.position, new Vector2(barJourneyLenght, 0), barfractJourney);
            }
        }
        if (button.rightIsPressed)
        {
            if (!button.leftIsPressed)
            {
                if (startRScreen)
                {
                    startTime = Time.time;
                    fractJourney = 0f;
                    barfractJourney = 0f;
                    startRScreen = false;
                }
                float distanceCovered = (Time.time - startTime) * speed;
                fractJourney = distanceCovered / journeyLenght;
                float bardistanceCovered = (Time.time - startTime) * barspeed;
                barfractJourney = bardistanceCovered / barJourneyLenght;
                camerapos.transform.position = Vector3.Lerp(camerapos.transform.position, new Vector3(journeyLenght, 10, -20), fractJourney);
                sideBars.transform.position = Vector2.Lerp(sideBars.transform.position, new Vector2(-barJourneyLenght, 0), barfractJourney);
            }
        }
        if (!button.rightIsPressed & !button.leftIsPressed)
        {
            if (!startRScreen | !startLScreen)
            {
                startTime = Time.time;
                fractJourney = 0f;
                barfractJourney = 0f;
                startRScreen = true;
                startLScreen = true;
            }
            float distanceCovered = (Time.time - startTime) * speed;
            fractJourney = distanceCovered / journeyLenght;
            float bardistanceCovered = (Time.time - startTime) * barspeed;
            barfractJourney = bardistanceCovered / barJourneyLenght;
            camerapos.transform.position = Vector3.Lerp(camerapos.transform.position, new Vector3(0, 10, -20), fractJourney);
            sideBars.transform.position = Vector2.Lerp(sideBars.transform.position, new Vector2(0, 0), barfractJourney);
        }
    }
     */

    /*
        public void Start()
    {
        button = left.GetComponent<ControlLeft>();
        startTime = Time.time;
        journeyLenght = -1f;// Vector3.Distance(camerapos.transform.position, new Vector3(-1f, 10, -20));
    }
    public void Update()
    {
        if (button.leftIsPressed)
        {
            if (button.rightIsPressed)
            {
                return;
            }
            else if(!button.rightIsPressed)
            {
                float distanceCovered = (Time.time - startTime) * speed;
                float fractJourney = distanceCovered / journeyLenght;
                camerapos.transform.position = Vector3.Lerp(camerapos.transform.position, new Vector3(-(journeyLenght), 10, -20), fractJourney);
            }
        }
        else if (!button.leftIsPressed)
        {

            float distanceCovered = (Time.time - startTime) * speed;
            float fractJourney = distanceCovered / journeyLenght;
            camerapos.transform.position = Vector3.Lerp(camerapos.transform.position, new Vector3(0, 10, -20), fractJourney);
        }
        if (button.rightIsPressed)
        {

        }
    }
     */

    /*
    private void UIMoveLeft()
    {
        Vector3 targetpos = new Vector3(transform.position.x - 150f, transform.position.y, transform.position.z);
        camera.transform.position = Vector3.Lerp(transform.position, targetpos, step);
    }


    public void Start()
    {
        button = left.GetComponent<ControlLeft>();
        step = Time.deltaTime * 0.2f;
    }

    public void Update()
    {
        if (button.leftIsPressed)
        {
            UIMoveLeft();
        }
    }*/
}
