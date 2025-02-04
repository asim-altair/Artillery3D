using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Gun", menuName = "Guns/new Gun")]
public class Gun : ScriptableObject
{
    public int health;
    public int maxHealth;
    public float mobility;
    public float maxMobility;
    public float reloadTime;
    public float maxReloadTime;
    public GameObject prefeb;
}
