using UnityEngine;

public class UiMovement : MonoBehaviour
{
    public GameObject left;

    public float step;
    public float startTime;
    public float journeyLength = 0.6f;//0.6f
    public float speed = 0.6f; // 0.6f
    public float fractJourney;

    private bool startLScreen;
    private bool startRScreen;
    
/*    public void LateUpdate()
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
                transform.position = Vector3.Lerp(transform.position, new Vector3(0, 10, -20), fractJourney);
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
                transform.position = Vector3.Lerp(transform.position, new Vector3(-(journeyLength), 10, -20), fractJourney);
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
                transform.position = Vector3.Lerp(transform.position, new Vector3(journeyLength, 10, -20), fractJourney);
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
            transform.position = Vector3.Lerp(transform.position, new Vector3(0, 10, -20), fractJourney);
        }
    }*/
}
