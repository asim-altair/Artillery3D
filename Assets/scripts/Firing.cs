using UnityEngine;

public class Firing : MonoBehaviour
{
    // Shooting variables
    public GameObject shell;
    public Transform firePoint;

    // recoil variables
    public GameObject recoilHolder;
    public float recoilAmount = 0.5f;
    public float recoilSpeed = 0.5f;
    private Vector3 recoilOriginalPos;

    // weapon reaction
    public GameObject deflectionControler;
    public float reactionAmount = 0.3f;
    public float reactionSpeed = 0.3f;
    private Vector3 originalPos;

    // Camera Shake
    public CameraShake cameraShake;

    // sounds
    private AudioSource shootSound;
    // particles
    public ParticleSystem shotParticle;
    public ParticleSystem smokeParticle;
    // trajectory
    private LineRenderer lineRenderer;
    public int linePoints = 100;
    public float simulationTimeStep = 0.1f; // Time step for trajectory simulation
    public float shellForce = 5f; // Match this with your Projectile's force
    public float gravity = 9.81f; // Match Unity gravity if not customized
    //crosshair
    public GameObject crosshair;
    public float crosshairRotationSpeed;
    //camera shaking veriables
    public float shakeDurration;
    public float shakeAmplitude;

    private float reloadingDelay = 3f;
    private float reloadTime;
    public Gun gun;

    private void Start()
    {
        // recoil position fetcher
        recoilOriginalPos = recoilHolder.transform.localPosition;
        // reaction position fetcher
        originalPos = deflectionControler.transform.localPosition;
        // sounds
        shootSound = GetComponent<AudioSource>();
        // trajectory
        lineRenderer = GetComponent<LineRenderer>();

        reloadTime = 3 / gun.reloadTime;
    }

    private void Update()
    {
        // recoiling
        recoilHolder.transform.localPosition = Vector3.Lerp(recoilHolder.transform.localPosition, recoilOriginalPos, recoilSpeed * Time.deltaTime);
        // reaction
        deflectionControler.transform.localPosition = Vector3.Lerp(deflectionControler.transform.localPosition, originalPos, reactionSpeed * Time.deltaTime);

        // Update trajectory
        DrawTrajectory();
        //crosshair
        crosshair.transform.Rotate(0, 0, crosshairRotationSpeed * Time.deltaTime);

        reloadingDelay += Time.deltaTime;
    }

    public void Shoot()
    {
        if(reloadingDelay >= reloadTime)
        {
            reloadingDelay = 0;
            // shoot
            Instantiate(shell, firePoint.position, firePoint.rotation);

            // recoil
            recoilHolder.transform.localPosition -= new Vector3(0, 0, recoilAmount);

            // reaction
            deflectionControler.transform.localPosition -= new Vector3(0, 0, reactionAmount);

            // camera shake
            cameraShake.ShakeTrigger(shakeDurration, shakeAmplitude);
            // sound
            shootSound.Play();
            // particle
            shotParticle.Play();
            smokeParticle.Play();
        }
        else
        {
            Debug.Log("Reloading");
        }
    }

    private void DrawTrajectory()
    {
        Vector3 startPosition = firePoint.position;
        Vector3 startVelocity = firePoint.forward * shellForce;

        lineRenderer.positionCount = 0; // Reset the line
        Vector3 currentPosition = startPosition;
        Vector3 currentVelocity = startVelocity;

        for (int i = 0; i < linePoints; i++)
        {
            lineRenderer.positionCount = i + 1;
            lineRenderer.SetPosition(i, currentPosition);

            // Check for collision
            if (Physics.Raycast(currentPosition, currentVelocity.normalized, out RaycastHit hit, currentVelocity.magnitude * simulationTimeStep))
            {
                if (hit.collider.gameObject.CompareTag("shell")) return;
                lineRenderer.SetPosition(i, hit.point); // Set the last point to the collision point
                crosshair.transform.position = hit.point;
                break; // Stop adding points
            }

            // Update position and velocity using physics equations
            currentVelocity += Vector3.down * gravity * simulationTimeStep; // Apply gravity
            currentPosition += currentVelocity * simulationTimeStep;
        }
    }

}
