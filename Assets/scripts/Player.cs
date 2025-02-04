using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public int money = 300;

    public int missions = 1;

    public int selectedMission;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddMoney(int value)
    {
        money += value;
    }
    public void RemoveMoney(int value)
    {
        money -= value;
    }

}
