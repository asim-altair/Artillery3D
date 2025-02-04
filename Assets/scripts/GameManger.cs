using System.Collections;
using UnityEngine;
using TMPro;

public class GameManger : MonoBehaviour
{
    private GameObject player;
    private bool gameOverTriggered = false;
    public bool missionPassed = false;

    public GameObject missionScreen;

    public int soldiers;
    public int vehicles;
    public int tanks;

    public TextMeshProUGUI soldiersCount;
    public TextMeshProUGUI vehiclesCount;
    public TextMeshProUGUI tanksCount;

    public TextMeshProUGUI soldiersReward;
    public TextMeshProUGUI vehiclesReward;
    public TextMeshProUGUI tanksReward;

    public TextMeshProUGUI missionHeading;


    private void Update()
    {
        if (!gameOverTriggered)
        {
            player = GameObject.FindGameObjectWithTag("Player");

            if (player == null || missionPassed)
            {
                gameOverTriggered = true;
                StartCoroutine(GameOver());
            }
        }


        soldiersCount.text = soldiers.ToString();
        vehiclesCount.text = vehicles.ToString();
        tanksCount.text = tanks.ToString();

    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(3);
        soldiersReward.text = (soldiers * 10).ToString();
        vehiclesReward.text = (vehicles * 100).ToString();
        tanksReward.text = (tanks * 200).ToString();

        Player.Instance.AddMoney((soldiers * 10) + (vehicles * 100) + (tanks * 200));

        if (missionPassed)
        {
            missionHeading.text = "Mission Passed";
            if(Player.Instance.selectedMission == Player.Instance.missions - 1)
            {
                if (Player.Instance.missions < 8)
                {
                    Player.Instance.missions++;
                }
            }
        }
        else
        {
            missionHeading.text = "Mission Failed!";
            missionHeading.color = Color.red;
        }

        missionScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
