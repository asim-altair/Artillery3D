using UnityEngine;
using UnityEngine.AI;

public class Projectile : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 50f; // Initial velocity magnitude
    public GameObject shell;
    private AudioSource blast;
    public ParticleSystem explosion;
    private CameraShake cameraShake;
    //camera shaking veriables
    public float shakeDurration;
    public float shakeAmplitude;

    public float force;
    public float upwards;
    public float radus;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Set the initial velocity directly
        rb.velocity = transform.forward * speed;

        // Get the AudioSource component
        blast = GetComponent<AudioSource>();

        cameraShake = GameObject.Find("camera holder").GetComponent<CameraShake>();
    }

    void Update()
    {
        // Align the projectile's rotation with its velocity
        if (rb && rb.velocity != Vector3.zero)
        {
            rb.MoveRotation(Quaternion.LookRotation(rb.velocity, transform.up));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Collider[] collidingObjs = Physics.OverlapSphere(transform.position, 5);
        for(int i = 0; i < collidingObjs.Length; i++)
        {
            if(collidingObjs[i].gameObject.GetComponent<Soldier>() != null)
            {
                Destroy(collidingObjs[i].gameObject.GetComponent<NavMeshAgent>());
            }
            Soldier soldier = collidingObjs[i].gameObject.GetComponent<Soldier>();
            Vehicle vehicle = collidingObjs[i].gameObject.GetComponent<Vehicle>();
            Tank tank = collidingObjs[i].gameObject.GetComponent<Tank>();
            Rigidbody rb = collidingObjs[i].gameObject.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.isKinematic = false;
                rb.AddExplosionForce(force, transform.position, radus, upwards, ForceMode.Impulse);
            }
            if(soldier != null)
            {
                soldier.hit = true;
                soldier.TakeDamage(40);
            }
            if(vehicle != null)
            {
                vehicle.TakeDamage(40);
            }
            if(tank != null)
            {
                tank.TakeDamage(40);
            }

        }
        // Play the sound effect
        if (blast)
        {
            blast.Play();
        }
        rb.velocity = Vector3.zero;
        Destroy(rb);
        explosion.Play();
        if(cameraShake != null)
        {
            cameraShake.ShakeTrigger(shakeDurration, shakeAmplitude);
        }
        // Destroy the collider to prevent further collisions
        Destroy(GetComponent<CapsuleCollider>());

        // Destroy the shell object
        Destroy(shell);

        // Destroy the projectile after a delay
        Destroy(gameObject, 3f);
    }
}
