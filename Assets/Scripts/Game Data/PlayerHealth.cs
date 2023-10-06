using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] private int maxHealth = 100;
    public int currentHealth;

    private bool onGameStart = false;

    #region Singleton

    public static PlayerHealth instance;

    private void Awake()
    {
        if (instance != null)
        {

            Debug.LogWarning("More than one instance of PlayerHealth Found on " + this.name);
            return;
        }
        instance = this;



    }

    #endregion


    private void Start()
    {
        if (!onGameStart)
        {
            currentHealth = maxHealth;
            onGameStart = true;
        }
    }


    public void SetHealthBar(HealthBar health)
    {
        health.setHealthOnStart(currentHealth, maxHealth);
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth > maxHealth) // make sure if adding health, not to go over max health
        {
            currentHealth = maxHealth;
        }
    }

}
