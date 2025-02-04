using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission1 : MonoBehaviour
{

    public GameObject cat;
    public Transform desiredPositionForSoldiers;

    private bool missionStarted = false;

    public GameManger gameManger;

    private void Update()
    {
        if (missionStarted == false)
        {
            StartCoroutine(Instantiater());
        }

        if(gameManger.soldiers >= 24)
        {
            gameManger.missionPassed = true;
        }
    }

    IEnumerator Instantiater()
    {
        missionStarted = true;
        Instantiate(cat, desiredPositionForSoldiers.position, desiredPositionForSoldiers.rotation);

        yield return new WaitForSeconds(10);
        Instantiate(cat, desiredPositionForSoldiers.position, desiredPositionForSoldiers.rotation);

        yield return new WaitForSeconds(10);
        Instantiate(cat, desiredPositionForSoldiers.position, desiredPositionForSoldiers.rotation);

        

        yield return null;
    }
}
