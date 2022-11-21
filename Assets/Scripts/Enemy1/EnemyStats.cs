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
        HealthBar = GetComponentInChildren<EnemyHealth>();
        if(HealthBar != null){
            HealthBar.SetHealth(health,maxHealth);
        }
    }

    void Update()
    {
        
    }

    public void damage(float damage)
    {
        health -= damage;
        if(HealthBar != null) HealthBar.SetHealth(health, maxHealth);

        if(health <= 0){

            // chance of getting health as a drop
            int healthChance = Random.Range(0,10);
            if(healthChance == 1){
                GameObject e = Instantiate(Resources.Load("Prefabs/broc") as GameObject);
                e.transform.position = transform.position;
                e.name = "broc";
            }else{
                int chance = Random.Range(1, 3);
                if(chance == 1){
                    GameObject e = Instantiate(Resources.Load("Prefabs/fries") as GameObject);
                    e.transform.position = transform.position;
                    e.name = "fries";
                }
            }

            PlayerStats.enemiesKilled++;
            Destroy (this.gameObject);
        }
        
    }
}
