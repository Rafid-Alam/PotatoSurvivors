using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float maxHealth = 100;
    public float health = 100;
    public EnemyHealth HealthBar;
    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        
    }

    public void damage(float damage)
    {
        health -= damage;
        HealthBar.SetHealth(health, maxHealth);

        if(health <= 0){
            // Add xp drop
            // 20% change of dropping xp 
            // Instantiate xp prefab

            PlayerStats.enemiesKilled++;
            Destroy (this.gameObject);
        }
        
    }
}
