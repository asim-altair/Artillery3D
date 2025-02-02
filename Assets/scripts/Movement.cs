using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public Transform elevationController;
    public Transform deflectionController;

    public float minElevation;
    public float maxElevation;

    public float minDeflection;
    public float maxDeflection;

    public float rotationSpeed = 0.2f;

    private float currElevation;
    private float currDeflection;

    public GameObject lWheel;
    public GameObject rWheel;
    
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector2 swipe = touch.deltaPosition;
            currDeflection += swipe.x * rotationSpeed * Time.deltaTime;
            currDeflection = Mathf.Clamp(currDeflection, minDeflection, maxDeflection);

            currElevation += swipe.y * rotationSpeed * Time.deltaTime;
            currElevation = Mathf.Clamp(currElevation, minElevation, maxElevation);

            deflectionController.localRotation = Quaternion.Euler(0, -currDeflection, 0);
            elevationController.localRotation = Quaternion.Euler(currElevation, 0, 0);

            lWheel.transform.localRotation = Quaternion.Euler(-currDeflection,0,0);
            rWheel.transform.localRotation = Quaternion.Euler(currDeflection,0,0);

        }
    }
}
