using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Vehicle : MonoBehaviour
{
    private GameObject destination;
    public NavMeshAgent vehicle;
    private Transform camera1;
    public GameObject canves;

    public float health = 100f;
    public Slider healthbar;
    private bool died = false;

    private float distance;
    public ParticleSystem muzzleFlash;
    private bool flashPlayed = false;

    public AudioSource fireSound;

    public GameObject destroyedVeh;

    private float waitTime = 0.3f;


    private void Start()
    {
        destination = GameObject.FindGameObjectWithTag("Player");
        camera1 = GameObject.Find("camera holder").transform;
    }
    void Update()
    {
        if (destination != null)
        {
            Move();
        }
        else
        {
            fireSound.Stop();
            muzzleFlash.Stop();
        }
        waitTime -= Time.deltaTime;
        CanvesFaceToCamera();
        healthbar.value = health;
        Die();
    }

    public void Move()
    {
        distance = Vector3.Distance(transform.position, destination.transform.position);

        if(vehicle != null)
        {
            if(distance > 20)
            {
                vehicle.SetDestination(destination.transform.position);
            }
            else
            {
                vehicle.isStopped = true;
                Shoot();
            }
        }
    }

    public void TakeDamage(float value)
    {
        health -= value;
    }

    private void Die()
    {
        if (health <= 0 && died == false)
        {
            Instantiate(destroyedVeh, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private void Shoot()
    {
        if(destination != null)
        {
            if (flashPlayed == false)
            {
                flashPlayed = true;
                muzzleFlash.Play();
                fireSound.Play();
            }
            if (waitTime <= 0)
            {
                Weapon weapon = destination.GetComponent<Weapon>();
                weapon.TakeDamage(10);
                waitTime = 0.3f;
            }
        }
    }

    void CanvesFaceToCamera()
    {
        Vector3 cameraDirection = transform.position - camera1.position;

        canves.transform.rotation = Quaternion.LookRotation(cameraDirection, Vector3.up);
    }
}
