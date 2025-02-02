using UnityEngine;
using UnityEngine.UI;

public class MissionSelector : MonoBehaviour
{
    public GameObject[] buttons;

    public Color color;
    public Color greenColor;

    private void Start()
    {
        for(int i = Player.Instance.missions; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<Button>().interactable = false;
        }
        buttons[Player.Instance.missions - 1].GetComponent<Image>().color = greenColor;
    }

    public void SelectMission(int value)
    {
        foreach (GameObject button in buttons)
        {
            Image image = button.GetComponent<Image>();
            image.color = color;
        }

        buttons[value].GetComponent<Image>().color = greenColor;
                
    }
}
