using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    
    public Image fill;


    public TextMeshProUGUI healthText;

    public bool isPlayerHealth = false;

    private void Start()
    {
        if (isPlayerHealth && PlayerHealth.instance != null) // if player health, set it to the player's health
        {
            Debug.Log("Loading PlayerHealth");
            PlayerHealth.instance.SetHealthBar(this);
        }
        else if (isPlayerHealth)
        {
            Debug.Log("Player Health Not Found || Setting Default Health");
                setHealthOnStart(100, 100);
        }
        
    }



    public void setMaxHealth(int maxHealth) // changes both current health and max health to maxHealth
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
        
        fill.color = gradient.Evaluate(1f);
    }



    public void setHealth(int health) // changes 
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);

    }




    public void setHealthOnStart(int health, int maxHealth)
    {

        setMaxHealth(maxHealth); // set maxhealth
        setHealth(health); // set current health
        healthText.text = health.ToString() + "/" + maxHealth.ToString(); // set health text
    }




    private void Update()
    {
        if(isPlayerHealth && PlayerHealth.instance != null)
        {
            PlayerHealth.instance.SetHealthBar(this);
        }
    }

}
