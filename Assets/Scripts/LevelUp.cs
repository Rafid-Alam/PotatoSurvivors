using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelUp : MonoBehaviour
{   
    // Use lvlpoints to upgrade abilities
    // The buttons will have to be updated to call different functions depending on the upgrade
    // Buttons in the level up menu calls function to handle the upgrades
    // lvlpoints should be decreased after an upgrade
    // player can choose to save points and use them later by clicking resume


    public static int lvlPoints;
    [SerializeField] private TMP_Text pointsLabel;
    public static bool leveled = false;
    public static bool LevelMenuActive;
    public GameObject LevelUpMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        LevelMenuActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(leveled){
            Pause();
            LevelMenuActive = true;
            leveled = false;
        }
        
        if ((Input.GetKeyDown(KeyCode.Escape) && LevelMenuActive) || lvlPoints == 0){
            Resume();
            LevelMenuActive = false;
        }

        if(pointsLabel != null) pointsLabel.text = "Points: " + lvlPoints;
    }

    public void Resume()
    {
        LevelUpMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    void Pause()
    {
        LevelUpMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }


    // Handles different buttons to upgrade
    public void hatUpgrade(){
        if(!validatePoints()) return;
        FireAutoProjectile.fireRate *= 0.8f;
        AutoProjectileAim.damage *= 1.25f;
        lvlPoints--;
    }

    public void knifeUpgrade(){
        if(!validatePoints()) return;
        SpawnKnife.knifeLevel++;

        if(SpawnKnife.knifeLevel != 1){
            SpawnKnife.timeToAttack *= 0.9f;
            KnifeProjectile.damage *= 1.15f;
        }
        lvlPoints--;
    }

    public void bombUpgrade(){  
        if(!validatePoints()) return;
        SpawnBomb.bombLevel++;

        if(SpawnBomb.bombLevel != 1)SpawnBomb.timeToAttack *= 0.85f;
        lvlPoints--;
    }

    public void healingUpgrade(){
        if(!validatePoints()) return;

        lvlPoints--;
    }

    public void healthUpgrade(){
        if(!validatePoints()) return;

        PlayerStats.maxHealth *= 1.15f;
        lvlPoints--;
    }

    public void speedUpgrade(){
        if(!validatePoints()) return;

        PlayerMovement.speed *= 1.1f;
        lvlPoints--;
    }

    private bool validatePoints(){
        return lvlPoints > 0;
    }
}
