using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Soldier : MonoBehaviour
{
    private GameObject destination;
    public NavMeshAgent soldier;
    private Transform camera1;
    public GameObject canves;
    private Rigidbody rb;
    private Animator animator;

    public float health = 30f;
    public Slider healthbar;
    private bool died = false;

    public Material deadMat;
    private Renderer mat;

    private float distance;

    public bool hit = false;

    public float reloadTime = 0.5f;

    public ParticleSystem muzzleFlash;
    private AudioSource shotSound;

    GameManger gameManger;


    private void Start()
    {
        destination = GameObject.FindGameObjectWithTag("Player");
        camera1 = GameObject.Find("camera holder").transform;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        mat = GetComponentInChildren<Renderer>();
        rb = GetComponent<Rigidbody>();
        shotSound = GetComponent<AudioSource>();
        gameManger = GameObject.Find("GameManger").GetComponent<GameManger>();
    }
    void Update()
    {
        
            if(destination == null)
            {
            animator.SetBool("isIdle", true);
                return;
            }
            else
            {
                MoveSoldier();
            }

        CanvesFaceToCamera();
        healthbar.value = health;
        Die();
    }

    public void MoveSoldier()
    {
        distance = Vector3.Distance(transform.position, destination.transform.position);
        if (!hit)
        {
            transform.LookAt(destination.transform.position);
        }
        if (soldier != null)
        {
            if (distance > 20)
            {
                soldier.SetDestination(destination.transform.position);
            }
            else if (distance <= 20)
            {
                animator.SetBool("isShooting", true);
                soldier.isStopped = true;
                rb.velocity = Vector3.zero;
            }
        }
        else
        {
            animator.SetBool("isShooting", false);
        }
    }

    public void TakeDamage(float value)
    {
        health -= value;
    }

    private void Die()
    {
        if(health <= 0 && died == false)
        {
            Destroy(soldier);
            animator.speed = 0;
            mat.material = new Material(deadMat);
            died = true;
            gameManger.soldiers++;
            Destroy(gameObject, 10);
        }
    }

    void CanvesFaceToCamera()
    {
        Vector3 cameraDirection = transform.position - camera1.position;

        canves.transform.rotation = Quaternion.LookRotation(cameraDirection, Vector3.up);
    }

    public void Shoot()
    {
        if(destination != null)
        {
            muzzleFlash.Play();
            shotSound.Play();
            Weapon weapon = destination.GetComponent<Weapon>();
            weapon.TakeDamage(5);
        }
    }
}
