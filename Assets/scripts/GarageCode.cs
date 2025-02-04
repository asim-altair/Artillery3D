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

    public TextMeshProUGUI[] priceForUpgrades;

    public GameObject lessMoney;

    public int[] price;
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

        if (gun.health == gun.maxHealth)
        {
            priceForUpgrades[0].text = "Max";
        }
        else
        {
            priceForUpgrades[0].text = price[0].ToString();
        }

        if (gun.mobility == gun.maxMobility)
        {
            priceForUpgrades[1].text = "Max";
        }
        else
        {
            priceForUpgrades[1].text = price[1].ToString();
        }

        if (gun.reloadTime == gun.maxReloadTime)
        {
            priceForUpgrades[2].text = "Max";
        }
        else
        {
            priceForUpgrades[2].text = price[2].ToString();
        }
    }

    public void UpgradeHealth()
    {
        if(Player.Instance.money >= price[0] && gun.health < gun.maxHealth)
        {
            gun.health += 50;
            Player.Instance.RemoveMoney(price[0]);
            price[0] += price[0] / 2;
        }
        else
        {
            DontHaveMoney();
        }
    }
    public void UpgradeMobility()
    {
        if (Player.Instance.money >= price[1] && gun.mobility < gun.maxMobility)
        {
            gun.mobility += 0.4f;
            Player.Instance.RemoveMoney(price[1]);
            price[1] += price[1] / 2;
        }
        else
        {
            DontHaveMoney();
        }
    }
    public void UpgradeReloading()
    {
        if (Player.Instance.money >= price[2] && gun.reloadTime < gun.maxReloadTime)
        {
            gun.reloadTime += 0.5f;
            Player.Instance.RemoveMoney(price[2]);
            price[2] += price[2] / 2;
        }
        else
        {
            DontHaveMoney();
        }
    }

    public void DontHaveMoney()
    {
        lessMoney.SetActive(true);
    }
}
