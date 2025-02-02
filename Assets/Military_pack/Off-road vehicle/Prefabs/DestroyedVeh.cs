using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedVeh : MonoBehaviour
{
    public GameObject[] parts;
    void Start()
    {
        foreach(GameObject part in parts)
        {
            Rigidbody rb = part.GetComponent<Rigidbody>();
            rb.AddExplosionForce(3, transform.position, 10, 7, ForceMode.Impulse); 
        }
    }
}
