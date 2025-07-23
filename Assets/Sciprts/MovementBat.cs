using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBat : MonoBehaviour
{
    public Transform startPoint; // Starting point of the curve
    public Transform endPoint; // Ending point of the curve
    public Transform controlPoint1; // First control point of the curve
    public Transform controlPoint2; // Second control point of the curve
    public float loopDuration = 5f; // Duration of each loop

    private float t = 0f; // Parameter to control the position along the curve
    private bool movingForward = true; // Flag to determine the direction of movement

    private void Update()
    {
        // Increment or decrement the parameter based on the elapsed time and direction of movement
        float deltaT = Time.deltaTime / loopDuration;
        t += movingForward ? deltaT : -deltaT;

        // Clamp the parameter between 0 and 1
        t = Mathf.Clamp01(t);

        // Calculate the position on the Bezier curve using the parameter
        Vector3 position = CalculateBezierPoint(t, startPoint.position, controlPoint1.position, controlPoint2.position, endPoint.position);

        // Move the object to the calculated position
        transform.position = position;

        // Check if the object has reached the end or start of the current loop
        if (t >= 1f && movingForward)
        {
            // Set the direction of movement to move backward
            movingForward = false;
        }
        else if (t <= 0f && !movingForward)
        {
            // Set the direction of movement to move forward
            movingForward = true;
        }
    }

    private Vector3 CalculateBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        float u = 1f - t;
        float tt = t * t;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * t;

        Vector3 point = uuu * p0; // (1-t)^3 * P0
        point += 3f * uu * t * p1; // 3 * (1-t)^2 * t * P1
        point += 3f * u * tt * p2; // 3 * (1-t) * t^2 * P2
        point += ttt * p3; // t^3 * P3

        return point;
    }
}

