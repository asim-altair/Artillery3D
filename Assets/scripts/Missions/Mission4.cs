﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission4 : MonoBehaviour
{

    public GameObject cat;
    public GameObject vehicle;
    public Transform desiredPositionForSoldiers;
    public Transform desiredPositionForSoldiers2;
    public Transform desiredPositionForVehicles;
    public Transform desiredPositionForVehicles2;

    private bool missionStarted = false;

    public GameManger gameManger;

    private void Update()
    {
        if (missionStarted == false)
        {
            StartCoroutine(Instantiater());
        }

        if(gameManger.soldiers >= 56 && gameManger.vehicles >= 6)
        {
            gameManger.missionPassed = true;
        }
    }

    IEnumerator Instantiater()
    {
        missionStarted = true;
        Instantiate(cat, desiredPositionForSoldiers.position, desiredPositionForSoldiers.rotation);
        Instantiate(vehicle, desiredPositionForVehicles.position, desiredPositionForVehicles.rotation);
        Instantiate(vehicle, desiredPositionForVehicles2.position, desiredPositionForVehicles2.rotation);
        yield return new WaitForSeconds(5);
        Instantiate(vehicle, desiredPositionForVehicles.position, desiredPositionForVehicles.rotation);
        Instantiate(vehicle, desiredPositionForVehicles2.position, desiredPositionForVehicles2.rotation);
        yield return new WaitForSeconds(10);
        Instantiate(cat, desiredPositionForSoldiers.position, desiredPositionForSoldiers.rotation);
        Instantiate(cat, desiredPositionForSoldiers2.position, desiredPositionForSoldiers2.rotation);
        yield return new WaitForSeconds(5);
        Instantiate(cat, desiredPositionForSoldiers.position, desiredPositionForSoldiers.rotation);
        Instantiate(cat, desiredPositionForSoldiers2.position, desiredPositionForSoldiers2.rotation);
        yield return new WaitForSeconds(10);
        Instantiate(cat, desiredPositionForSoldiers.position, desiredPositionForSoldiers.rotation);
        Instantiate(vehicle, desiredPositionForVehicles.position, desiredPositionForVehicles.rotation);
        Instantiate(cat, desiredPositionForSoldiers2.position, desiredPositionForSoldiers2.rotation);
        Instantiate(vehicle, desiredPositionForVehicles2.position, desiredPositionForVehicles2.rotation);

        

        yield return null;
    }
}
