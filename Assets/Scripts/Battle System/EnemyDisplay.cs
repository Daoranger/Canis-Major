using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDisplay : MonoBehaviour
{


    public EnemyCreator enemy;
    public Image enemyImage;
    public HealthBar enemyHealthBar;
    public TextMeshProUGUI enemyName;

    public int currentHealth;
    private int maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        if (DataSceneTransfer.instance == null)
        {
            Debug.LogError("Data Transfer not loaded into scene or inActive");
            return;
        }
        enemy = DataSceneTransfer.instance.enemy;
        maxHealth = enemy.health;
        currentHealth = enemy.health;
        
        enemyImage.sprite = enemy.characterImage;
        enemyName.text = enemy.name;


        enemyHealthBar.setMaxHealth(maxHealth);
        enemyHealthBar.setHealthOnStart(currentHealth, maxHealth);

    }


    public void changeHealth(int damage)
    {
        currentHealth -= damage;
        enemyHealthBar.setHealthOnStart(currentHealth, maxHealth);
    }
}
