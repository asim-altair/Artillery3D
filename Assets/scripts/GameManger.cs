using System.Collections;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    private GameObject player;
    private bool gameOverTriggered = false;
    private bool missionPassTriggered = false;
    public bool missionPassed = false;

    public int soldiers;

    private void Update()
    {
        if (!gameOverTriggered)
        {
            player = GameObject.FindGameObjectWithTag("Player");

            if (player == null)
            {
                gameOverTriggered = true;
                StartCoroutine(GameOver());
            }
        }

        if (!missionPassTriggered)
        {
            if(missionPassed == true)
            {
                StartCoroutine(MissionPassed());
            }
        }
        Debug.Log(soldiers);
        Debug.Log(missionPassed);
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(3);
        Debug.Log(soldiers);
        Time.timeScale = 0;
    }

    IEnumerator MissionPassed()
    {
        missionPassTriggered = true;
        yield return new WaitForSeconds(5);
        Time.timeScale = 0;
    }
}
