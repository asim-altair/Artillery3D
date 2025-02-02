using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GarageCode : MonoBehaviour
{
    public TextMeshProUGUI moneyfield;

    public TextMeshProUGUI healthValue;
    public Slider healthUpgradeSlider;

    public TextMeshProUGUI mobilityValue;
    public Slider mobilitySlider;

    public TextMeshProUGUI reloadTimeValue;
    public Slider reloadSlider;

    public Gun gun;
    void Update()
    {
        moneyfield.text = Player.Instance.money.ToString();
        // health bar upgrade
        healthValue.text = gun.health.ToString();
        healthUpgradeSlider.value = gun.health;
        // mobility upgrade
        mobilityValue.text = gun.mobility.ToString();
        mobilitySlider.value = gun.mobility;
        //reload time upgrade
        reloadTimeValue.text = gun.reloadTime.ToString();
        reloadSlider.value = gun.reloadTime;

    }

    public void UpgradeHealth()
    {
        if(Player.Instance.money >= 500 && gun.health < gun.maxHealth)
        {
            gun.health += 50;
            Player.Instance.RemoveMoney(500);
        }
        else
        {
            Debug.Log("Don't have money");
        }
    }
    public void UpgradeMobility()
    {
        if (Player.Instance.money >= 500)
        {
            gun.mobility += 1;
            Player.Instance.RemoveMoney(500);
        }
        else
        {
            Debug.Log("Don't have money");
        }
    }
    public void UpgradeReloading()
    {
        if (Player.Instance.money >= 500)
        {
            gun.reloadTime += 1;
            Player.Instance.RemoveMoney(500);
        }
        else
        {
            Debug.Log("Don't have money");
        }
    }
}
