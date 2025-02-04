using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMainMenu : MonoBehaviour
{
    public float rotationSpeed = 5f;

    private float moveX;
    private float moveY;

    private bool autoRotate = true;

    private void Update()
    {
        if (autoRotate)
        {
            transform.Rotate(0, 10 * Time.deltaTime, 0, Space.Self);
        }

        if (Input.touchCount > 0)
        {
            autoRotate = false;
            Touch touch = Input.GetTouch(0);

            // Get the swipe delta
            Vector2 swipe = touch.deltaPosition;

            // Accumulate rotation values (scale by Time.deltaTime for frame-rate independence)
            moveX += swipe.x * rotationSpeed * Time.deltaTime;
            moveY += swipe.y * rotationSpeed * Time.deltaTime;

            // Clamp vertical rotation to avoid flipping
            moveY = Mathf.Clamp(moveY, -20f, 15f);

            // Compute the desired rotation
            Quaternion desiredRotation = Quaternion.Euler(-moveY, moveX + 140, 0);

            // Smoothly interpolate to the desired rotation
            transform.localRotation = Quaternion.Lerp(transform.localRotation, desiredRotation, Time.deltaTime * rotationSpeed);
        }
    }
}
