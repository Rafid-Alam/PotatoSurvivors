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
    [SerializeField] private TextMeshProUGUI killCount;
    [SerializeField] private TextMeshProUGUI levelDisplay;
    [SerializeField] private TextMeshProUGUI timer;
    [SerializeField] private TextMeshProUGUI scoreLabel;
    [SerializeField] private TextMeshProUGUI maxScoreLabel;
    public Animator animator;

    public float currentTime;
    private int score;
    public static int maxScore = 0;
    public float maxHealth = 100;
    public float health = 100;
    public static int enemiesKilled;
    public static float playerXP;
    public static float xpNeeded;
    public static float level;
    public static int friesCollected;
    public static int brocCollected;
    
    void Start()
    {
        score = 0;
        health = maxHealth;
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

        // UI elements 
        killCount = GetComponent<TextMeshProUGUI>();
        levelDisplay = GetComponent<TextMeshProUGUI>();
        timer = GetComponent<TextMeshProUGUI>();
        scoreLabel = GetComponent<TextMeshProUGUI>();
        maxScoreLabel = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        // Score Calculation
        score = (friesCollected * 500) + (enemiesKilled * 200) + (brocCollected * 300);

        // Level up 
        if(playerXP >= xpNeeded){
            playerXP = playerXP - xpNeeded;
            xpNeeded = xpNeeded * 1.15f; // xp needed is increased every level up
            SpawnEnemy1.spawnCooldown *= 0.8f; // cooldown gets smaller every level up
            level++;

            // level up options - Weapon ideas
            // splash damage ability - cooking oil
            // rotating pot - similar to the bible from vampire survivors
            // Healing - ability heals over time
            // Throwing knife that follow mouse
            // Something like onion in vampire survivors
            AutoProjectileAim.damage *= 1.5f;
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
    }

    public void damage(float damage){
        health -= damage;
        HealthBar.SetHealth(health, maxHealth);

        if(health <= 0){
            // updates max score and moves to gameover
            maxScore = Math.Max(maxScore, score);
            SceneManager.LoadScene("GameOver");
        }

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
            HealthBar.SetHealth(health,maxHealth);
            Destroy(col.gameObject);
        }
    }
}
