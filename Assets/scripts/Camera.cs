using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    private void LateUpdate()
    {
        if(target != null)
        {
            transform.localRotation = Quaternion.Lerp(transform.rotation, target.rotation, Time.deltaTime);
        }
    }
}
