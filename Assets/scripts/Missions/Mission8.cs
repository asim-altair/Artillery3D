using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission8 : MonoBehaviour
{

    public GameObject cat;
    public GameObject vehicle;
    public GameObject tank;
    public Transform desiredPositionForSoldiers;
    public Transform desiredPositionForSoldiers2;
    public Transform desiredPositionForVehicles;
    public Transform desiredPositionForVehicles2;
    public Transform desiredPositionForVehicles3;

    private bool missionStarted = false;

    public GameManger gameManger;

    private void Update()
    {
        if (missionStarted == false)
        {
            StartCoroutine(Instantiater());
        }

        if(gameManger.soldiers >= 16 && gameManger.vehicles >= 10 && gameManger.tanks >= 9)
        {
            gameManger.missionPassed = true;
        }
    }

    IEnumerator Instantiater()
    {
        missionStarted = true;
        Instantiate(tank, desiredPositionForSoldiers.position, desiredPositionForSoldiers.rotation);
        Instantiate(tank, desiredPositionForVehicles.position, desiredPositionForVehicles.rotation);
        Instantiate(vehicle, desiredPositionForVehicles2.position, desiredPositionForVehicles2.rotation);
        Instantiate(vehicle, desiredPositionForVehicles3.position, desiredPositionForVehicles3.rotation);
        yield return new WaitForSeconds(5);
        Instantiate(vehicle, desiredPositionForVehicles.position, desiredPositionForVehicles.rotation);
        Instantiate(vehicle, desiredPositionForVehicles2.position, desiredPositionForVehicles2.rotation);
        Instantiate(tank, desiredPositionForVehicles3.position, desiredPositionForVehicles3.rotation);
        yield return new WaitForSeconds(10);
        Instantiate(vehicle, desiredPositionForVehicles.position, desiredPositionForVehicles.rotation);
        Instantiate(vehicle, desiredPositionForVehicles2.position, desiredPositionForVehicles2.rotation);
        Instantiate(tank, desiredPositionForSoldiers.position, desiredPositionForSoldiers.rotation);
        Instantiate(cat, desiredPositionForSoldiers2.position, desiredPositionForSoldiers2.rotation);
        yield return new WaitForSeconds(5);
        Instantiate(vehicle, desiredPositionForVehicles.position, desiredPositionForVehicles.rotation);
        Instantiate(vehicle, desiredPositionForVehicles2.position, desiredPositionForVehicles2.rotation);
        yield return new WaitForSeconds(5);
        Instantiate(vehicle, desiredPositionForVehicles.position, desiredPositionForVehicles.rotation);
        Instantiate(vehicle, desiredPositionForVehicles2.position, desiredPositionForVehicles2.rotation);
        Instantiate(tank, desiredPositionForVehicles3.position, desiredPositionForVehicles3.rotation);
        yield return new WaitForSeconds(10);
        Instantiate(cat, desiredPositionForSoldiers.position, desiredPositionForSoldiers.rotation);
        Instantiate(tank, desiredPositionForVehicles.position, desiredPositionForVehicles.rotation);
        Instantiate(tank, desiredPositionForSoldiers2.position, desiredPositionForSoldiers2.rotation);
        Instantiate(tank, desiredPositionForVehicles2.position, desiredPositionForVehicles2.rotation);
        Instantiate(tank, desiredPositionForVehicles3.position, desiredPositionForVehicles3.rotation);

        

        yield return null;
    }
}
