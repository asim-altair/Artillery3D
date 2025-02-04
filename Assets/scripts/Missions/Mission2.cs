using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission2 : MonoBehaviour
{

    public GameObject cat;
    public Transform desiredPositionForSoldiers;
    public Transform desiredPositionForSoldiers2;

    private bool missionStarted = false;

    public GameManger gameManger;

    private void Update()
    {
        if (missionStarted == false)
        {
            StartCoroutine(Instantiater());
        }

        if(gameManger.soldiers >= 40)
        {
            gameManger.missionPassed = true;
        }
    }

    IEnumerator Instantiater()
    {
        missionStarted = true;
        Instantiate(cat, desiredPositionForSoldiers.position, desiredPositionForSoldiers.rotation);
        Instantiate(cat, desiredPositionForSoldiers2.position, desiredPositionForSoldiers2.rotation);

        yield return new WaitForSeconds(10);
        Instantiate(cat, desiredPositionForSoldiers.position, desiredPositionForSoldiers.rotation);

        yield return new WaitForSeconds(10);
        Instantiate(cat, desiredPositionForSoldiers.position, desiredPositionForSoldiers.rotation);
        Instantiate(cat, desiredPositionForSoldiers2.position, desiredPositionForSoldiers2.rotation);

        

        yield return null;
    }
}
