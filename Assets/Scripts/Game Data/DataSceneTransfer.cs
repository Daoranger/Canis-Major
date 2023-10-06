using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataSceneTransfer : MonoBehaviour
{

    #region Singleton

    public static DataSceneTransfer instance;

    private void Awake()
    {
        if (instance != null)
        {

            Debug.LogWarning("More than one instance of DataSceneTransfer Found!");
            return;
        }
        instance = this;



    }

    #endregion

    public List<bool> levelIsActivated;
    public List<bool> treasureWasTaken;

    public EnemyCreator enemy;
    public StoryScene scene;

    public string activeLevelName;
    public bool battleWon = false;

    public void addLevelActive(List<bool> levels)
    {
        levelIsActivated = new List<bool>();
        levelIsActivated = levels;
    }

    public void addTreasureData(List<bool> treasure)
    {
        treasureWasTaken = new List<bool>();
        treasureWasTaken = treasure;
    }


    public void add(EnemyCreator loadEnemy, StoryScene loadScene)
    {
        enemy = loadEnemy;
        scene = loadScene;
        OpenSceneSequencer();
    }

    public void loadBattleScene()
    {
        Debug.Log("Loading Battle Scene with " + enemy + " as the enemy...");
        SceneManager.LoadScene("Battle System");
    }


    private void OpenSceneSequencer()
    {
        if (enemy != null && scene != null || enemy == null && scene != null) // Both Enemy and Dialogue is Loaded or Just Dialogue
        {
            Debug.Log("Loading Scene " + scene.name + "...");
            SceneManager.LoadScene("Visual Novel");
        }
        else if (scene == null && enemy != null) // There is only an Enemy Loaded
        {
            Debug.Log("Enemy Data Loaded || Starting Battle System");
            Debug.Log("Loading Battle with " + enemy.name + " as the enemy...");
            SceneManager.LoadScene("Battle System");
        }
        else // There is No Scene or Enemy Loaded
        {
            Debug.Log("No Enemy or Scene is loaded");
        }
    }


}
