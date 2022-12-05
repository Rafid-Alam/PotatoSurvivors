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
    public GameObject LevelUpMenuUI;

    // Start is called before the first frame update
    void Start()
    {
        lvlPoints = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(leveled){
            Pause();
            leveled = false;
        }
        pointsLabel.text = "Points: " + lvlPoints;
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
}
