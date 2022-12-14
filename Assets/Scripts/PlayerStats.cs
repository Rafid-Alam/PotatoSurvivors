using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    // UI elements
    public PlayerHealth HealthBar;
    public Slider xpBar;
    [SerializeField] private TMP_Text killCount;
    [SerializeField] private TMP_Text levelDisplay;
    [SerializeField] private TMP_Text timer;
    [SerializeField] private TMP_Text scoreLabel;
    [SerializeField] private TMP_Text maxScoreLabel;
    public Animator anim;

    private int healCooldown;
    public float currentTime;
    private int score;
    public static int maxScore = 0;
    public static float maxHealth;
    public static float health;
    public static int enemiesKilled;
    public static float playerXP;
    public static float xpNeeded;
    public static float level;
    public static int friesCollected;
    public static int brocCollected;
    public static float timeDiff;
    public static int healingLevel;

    void Start()
    {
        anim = GetComponent<Animator>();
        healCooldown = 1;
        healingLevel = 0;
        LevelUp.lvlPoints = 0;
        score = 0;
        timeDiff = 30;
        health = 100;
        maxHealth = 100;
        level = 1;
        enemiesKilled = 0;
        playerXP = 0;
        xpNeeded = 15;
        currentTime = 0f;
        brocCollected = 0;
        friesCollected = 0;
        HealthBar = GetComponentInChildren<PlayerHealth>();
        if(HealthBar != null){
            HealthBar.SetHealth(health,maxHealth);
        }
    }

    void Update()
    {
        // Score Calculation
        score = (friesCollected * 50) + (enemiesKilled * 20) + (brocCollected * 30);

        // Level up 
        if(playerXP >= xpNeeded){
            playerXP = playerXP - xpNeeded;
            xpNeeded = xpNeeded * 1.1f;
            level++;

            // Level up function
             // this will make level up menu pop-up
            LevelUp.leveled = true;
            LevelUp.lvlPoints++;
        }

        // Difficulty increases over time
        // spawn cooldown increases every 30 seconds
        if(currentTime - timeDiff >= 0){
            SpawnEnemy1.spawnCooldown *= 0.9f;
            timeDiff += 30;
        }


        // Healing ability
        if(healingLevel != 0){
            if(Time.time >= healCooldown){
                healCooldown=Mathf.FloorToInt(Time.time)+1;
                healing();
            }   
        }
        

        // Updates time
        currentTime += Time.deltaTime;
        // Updates Player stats
        if(killCount != null) killCount.text = "x" + enemiesKilled;
        if(levelDisplay != null) levelDisplay.text = "LVL." + level;
        if(xpBar != null) xpBar.value = (playerXP/xpNeeded);
        var time = TimeSpan.FromSeconds(currentTime);
        if(timer != null) timer.text = string.Format("{0:00}:{1:00}", time.Minutes, time.Seconds);
        if(scoreLabel != null) scoreLabel.text = "Score: " + score;
        if(maxScoreLabel != null) maxScoreLabel.text = "Max Score: " + maxScore;
        if(HealthBar != null) updateHealthBar();
    }

    IEnumerator TimerForHeroDeath() // this code shows hero death animation before loading "Game Over" scene
    {
        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene("GameOver");
    }

    public void damage(float damage){
        health -= damage;
        updateHealthBar();

        if(health <= 0){
            // updates max score and moves to gameover
            maxScore = Math.Max(maxScore, score);
            anim.Play("hero_death");
            StartCoroutine(TimerForHeroDeath());
        }
    }

    public static void upgradeMaxHealth(){
        maxHealth *= 1.15f;
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.name == "fries"){
            playerXP += 5;
            friesCollected++;
            Destroy(col.gameObject);
        }else if(col.gameObject.name == "broc"){
            health += 10;
            brocCollected++;
            if(health > maxHealth) health = maxHealth;
            updateHealthBar();
            Destroy(col.gameObject);
        }
    }

    void updateHealthBar(){
        HealthBar.SetHealth(health,maxHealth);
    }

    void healing(){
        health += 0.25f * healingLevel;
        if(health > maxHealth) health = maxHealth;
    }
}
