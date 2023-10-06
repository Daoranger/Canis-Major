using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{

    // Chances Are Hard Coded  -> Work on Changing to make chance based off of percentage setter from editor

    //public HealthBar playerHealth;
    public EnemyDisplay enemyHealth;

    private int playerHealthBefore;

    private void Start()
    {
        if(PlayerHealth.instance != null)
        {
            playerHealthBefore = PlayerHealth.instance.currentHealth;
        }
    }
    public void AttackMove(int damage)
    {
        int chance = Random.Range(0, 20);


        if (chance < 4) // 0 - 4                                            miss!
        {
            Debug.Log("Player Missed!");
        } 


        else if (chance < 10)  // 5 - 9                                     Critical hit! 
        { 
            enemyHealth.changeHealth(Mathf.RoundToInt(damage * 1.5f));
            Debug.Log("Player Crits for " + Mathf.RoundToInt(damage * 1.5f));       
        }

 
        else if (chance < 20) { // 10 - 20                                  Default Hit! 50% 
        enemyHealth.changeHealth(damage);
        Debug.Log("Player Hits for " + damage);        
        }


        
        EnemyAttacks();
        battleWonCheck();
    }

    private void EnemyAttacks()
    {
        int damage = enemyHealth.enemy.damage;

        int chance = Random.Range(0, 20);


        if (chance < 4) // 0 - 4 miss!
        {
            Debug.Log("Player Missed!");
        } 


        else if (chance < 10) // 5 - 9 Critical hit! 
        {
            PlayerHealth.instance.TakeDamage(Mathf.RoundToInt(damage * 1.5f));
            Debug.Log("Enemy Crits for " + Mathf.RoundToInt(damage * 1.5f) + "!");
        } 


        else if (chance < 20) // 10 - 20 Default Hit! 50% 
        {
            PlayerHealth.instance.TakeDamage(damage);
            Debug.Log("Enemy Hits for " + damage + "!");
        }
        

    }

    private void battleWonCheck() // check to see if player has won (Reset Enemy health > Upload win bool to data > Return to Levels
    {
        if (PlayerHealth.instance.currentHealth <= 0) // player died
        {
            Debug.Log("Player has Lost");


            DataSceneTransfer.instance.battleWon = false;
            PlayerHealth.instance.currentHealth = playerHealthBefore; // resets Player health before fight
            SceneManager.LoadScene("Level Creator"); // Return to Level Select
        }
        else if (enemyHealth.currentHealth <= 0) // player won
        {
            Debug.Log("Player has won");
            DataSceneTransfer.instance.battleWon = true;

            SceneManager.LoadScene("Level Creator"); // Return to Level Select
        }

    }

    public void FleeFromFight()
    {
        Debug.Log("Player has Fled!");
        DataSceneTransfer.instance.battleWon = false;

        SceneManager.LoadScene("Level Creator"); // Return to Level Select

    }
}
