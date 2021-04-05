using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform[] targets;
    public float smoothSpeed = 0.125f;
    private Vector3 _offset;
    public bool offsetCurrentPosition = true;


    private void Start()
    {
        if (offsetCurrentPosition)
        {
            _offset = transform.position;
        }
    }

    private void FixedUpdate ()
    {
        var desiredPosition = GetTarget() + _offset;
        var smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }

    private Vector3 GetTarget()
    {
        var sum = new Vector3();
        foreach (var target in targets)
        {
            sum += target.position;
        }
        sum /= targets.Length;
        return sum;
    }
}
