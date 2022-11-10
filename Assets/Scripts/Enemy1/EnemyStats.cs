using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float maxHealth = 100;
    public float health = 100;
    public EnemyHealth HealthBar;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        //HealthBar = GetComponent<EnemyHealth>();
        //HealthBar = transform.GetComponentInChildren<EnemyHealth>();
        //HealthBar.SetHealth(health,maxHealth);
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
            Destroy (this.gameObject);
        }
        
    }
}
