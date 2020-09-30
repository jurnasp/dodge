using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform[] targets;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private void FixedUpdate ()
    {
        var desiredPosition = GetTarget() + offset;
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
