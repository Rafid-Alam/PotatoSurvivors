using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public PlayerHealth HealthBar;
    public Slider xpBar;
    [SerializeField] private TextMeshProUGUI killCount;
    [SerializeField] private TextMeshProUGUI levelDisplay;
    public float maxHealth = 100;
    public float health = 100;
    public static int enemiesKilled;
    public static float playerXP;
    public static float xpNeeded;
    public static float level;
    
    void Start()
    {
        health = maxHealth;
        level = 1;
        enemiesKilled = 0;
        playerXP = 0;
        xpNeeded = 15;
        HealthBar.SetHealth(health,maxHealth);
        killCount = GetComponent<TextMeshProUGUI>();
        levelDisplay = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        
        

        // Level up 
        if(playerXP >= xpNeeded){
            playerXP = playerXP - xpNeeded;
            xpNeeded = xpNeeded * 1.15f; // xp needed is increased every level up
            SpawnEnemy1.spawnCooldown *= 0.8f; // cooldown gets smaller every level up
            level++;
            // call level up - improve later to give upgrade options
            //FireAutoProjectile.projectiles++;
            AutoProjectileAim.damage *= 1.2f;
        }

        // Updates killcount text
        if(killCount != null) killCount.text = "x" + enemiesKilled;
        if(levelDisplay != null) levelDisplay.text = "LVL." + level;
        if(xpBar != null) xpBar.value = (playerXP/xpNeeded);

    }

    public void damage(float damage){
        health -= damage;
        HealthBar.SetHealth(health, maxHealth);

        if(health <= 0){
            //Game Over
            //Destroy (this.gameObject);
            SceneManager.LoadScene("GameOver");
        }
        
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.name == "fries"){
            playerXP += 5;
            Destroy(col.gameObject);
        }
    }
}
