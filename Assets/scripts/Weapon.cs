using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public AudioSource[] hittingSounds;
    private float health = 200;
    private int soundPlayed = 0;
    public Slider healthBar;
    public Image imageEffect;
    private float waitTimeForEffect = 0.1f;

    public bool isDead = false;
    public GameObject destroyed;


    private void Update()
    {
        healthBar.value = health;
        if(imageEffect.enabled == true)
        {
            if(waitTimeForEffect <= 0)
            {
                imageEffect.enabled = false;
                waitTimeForEffect = 0.1f;
            }
            waitTimeForEffect -= Time.deltaTime;
        }
        Die();
    }

    public void TakeDamage(float value)
    {
        health -= value;
        imageEffect.enabled = true;
        soundPlayed++;
        int randomValue = Random.Range(0, 3);
        if(soundPlayed >= 5)
        {
            hittingSounds[randomValue].Play();
            soundPlayed = 0;
        }
    }

    void Die()
    {
        if(health <= 0 && isDead == false)
        {
            Instantiate(destroyed, transform.position, transform.rotation);
            isDead = true;
            Destroy(gameObject);
        }
    }
}
