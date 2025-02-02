using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Gun", menuName = "Guns/new Gun")]
public class Gun : ScriptableObject
{
    public int health;
    public int maxHealth;
    public int mobility;
    public float reloadTime;
    public GameObject prefeb;
}
