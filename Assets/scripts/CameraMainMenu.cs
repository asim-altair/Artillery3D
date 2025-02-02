using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMainMenu : MonoBehaviour
{
    public float rotationSpeed = 5f;

    private float moveX;
    private float moveY;

    private void Start()
    {

    }

    private void Update()
    {
        

        if (Input.touchCount > 0)
        {
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
