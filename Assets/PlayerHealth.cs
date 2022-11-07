using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider Slider; 
    public Color Low;
    public Color High;
    public Vector3 Offset;
    public float maxHealth = 100;
    public float health = 100;


    void Start()
    {
        health = maxHealth;
        SetHealth(health, maxHealth);
        Slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low, High, Slider.normalizedValue);
    }

    // Update is called once per frame
    void Update()
    {
        SetHealth(health, maxHealth);
        Slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);
    }

    public void SetHealth(float health, float maxHealth)
    {
        Slider.gameObject.SetActive(health <= maxHealth);
        Slider.value = health;
        Slider.maxValue = maxHealth;

        Slider.fillRect.GetComponentInChildren<Image>().color = 
        Color.Lerp(Low, High, Slider.normalizedValue);
        if(health <= 0){
            //Game Over
        }
    }
    public void damage(float damage)
    {
        Slider.gameObject.SetActive(health <= maxHealth);
        health -= damage;
        Slider.value = health;

        Slider.fillRect.GetComponentInChildren<Image>().color = 
        Color.Lerp(Low, High, Slider.normalizedValue);
        if(health <= 0){
            //Game Over
        }
    }
}
