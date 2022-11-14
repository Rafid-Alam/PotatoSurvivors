using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth = 100;
    public float health = 100;
    public static int enemiesKilled;
    public PlayerHealth HealthBar;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        enemiesKilled = 0;
        HealthBar.SetHealth(health,maxHealth);
        //SetHealth(health, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void damage(float damage)
    {
        health -= damage;
        HealthBar.SetHealth(health, maxHealth);

        if(health <= 0){
            //Game Over
            //Destroy (this.gameObject);
            SceneManager.LoadScene("GameOver");
        }
        
    }
}
