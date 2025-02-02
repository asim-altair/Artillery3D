using System.Collections;
using UnityEngine;

public class Scene1 : MonoBehaviour
{
    private Vector3 initialPosition;
    public Transform desiredPosition;
    private Vector3 target;
    public GameObject camera2;
    private GameObject player;
    public GameObject canves;

    private void Start()
    {
        initialPosition = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(Mission());
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * 2f);

    }

    IEnumerator Mission()
    {
        Camera camera = GetComponent<Camera>();
        CameraShake cameraShake = GetComponent<CameraShake>();
        Movement movement = player.GetComponent<Movement>();
        Firing firing = player.GetComponent<Firing>();
        camera.enabled = false;
        cameraShake.enabled = false;
        movement.enabled = false;
        firing.enabled = false;
        canves.SetActive(false);
        target = desiredPosition.position;
        yield return new WaitForSeconds(3f);
        target = initialPosition;
        yield return new WaitForSeconds(3f);
        camera.enabled = true;
        cameraShake.enabled = true;
        movement.enabled = true;
        firing.enabled = true;
        canves.SetActive(true);
        this.enabled = false;
        yield return null;
    }

}
