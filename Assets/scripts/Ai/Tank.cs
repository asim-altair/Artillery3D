using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Tank : MonoBehaviour
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

    public AudioSource fireSound;

    public GameObject destroyedVeh;

    private float waitTime = 0;

    GameManger gameManger;


    private void Start()
    {
        destination = GameObject.FindGameObjectWithTag("Player");
        camera1 = GameObject.Find("camera holder").transform;
        gameManger = GameObject.Find("GameManger").GetComponent<GameManger>();
    }
    void Update()
    {
        if (destination != null)
        {
            Move();
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
            gameManger.tanks++;
            Instantiate(destroyedVeh, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private void Shoot()
    {
        if(destination != null)
        {
            if(waitTime < 0)
            {
                waitTime = 3;
                muzzleFlash.Play();
                fireSound.Play();
                Weapon weapon = destination.GetComponent<Weapon>();
                weapon.TakeDamage(50);
            }
                
        }
    }

    void CanvesFaceToCamera()
    {
        Vector3 cameraDirection = transform.position - camera1.position;

        canves.transform.rotation = Quaternion.LookRotation(cameraDirection, Vector3.up);
    }
}
