using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSaveData : MonoBehaviour
{
    
    

    public LevelData[] levelData; // store all levelBlocks in this level

    public TreasureItems[] treasureLevels;

    public List<bool> hasBeenPlayed; // store whether level block is blocked out

    public List<bool> treasureWasClaimed;

    private void Start()
    {
        levelData = GetComponentsInChildren<LevelData>(); // grabs all gameobjects with LevelData Component (all level block prefabs)
        treasureLevels = GetComponentsInChildren<TreasureItems>();

        if(DataSceneTransfer.instance.levelIsActivated.Count != 0) // If DataSceneTransfer has saved level data, change levels to equal that
        {
            LoadData();
        }
    }


    public void SaveData() // saves all changes that have been done in the level
    {
        hasBeenPlayed = new List<bool>(); // cleans old data from storage
        treasureWasClaimed = new List<bool>();

        foreach (TreasureItems treasure in treasureLevels) // saves if Treasure Levels have been used
        {
            treasureWasClaimed.Add(treasure.itemsHaveBeenAdded);
        }


        foreach (LevelData levelBlock in levelData) // updates list with new data
        {
            hasBeenPlayed.Add(levelBlock.firstTimeOpen);

            if (levelBlock.levelInPlay)
            {
                DataSceneTransfer.instance.activeLevelName = levelBlock.name;
            }
        }

        // ### LOAD DATA INTO SAVE ###
        DataSceneTransfer.instance.addTreasureData(treasureWasClaimed);
        DataSceneTransfer.instance.addLevelActive(hasBeenPlayed); 
        // adds data to data manager for multi-scene usage 
        //(when returning back to level scene, will use LoadData() to transfer data back

    }

    public void LoadData()
    {

        foreach (bool blocked in DataSceneTransfer.instance.levelIsActivated) // adds data to levels gameObject in each Level area
        {
            hasBeenPlayed.Add(blocked);
        }

        foreach (bool treasureTaken in DataSceneTransfer.instance.treasureWasTaken) // adds data for treasure already being opened
        {
            treasureWasClaimed.Add(treasureTaken);
        }

        for (int i = 0; i < levelData.Length; i++) // changes prefab levels to the saved data now in the LevelManager
        {
            if (levelData[i].name == DataSceneTransfer.instance.activeLevelName && !DataSceneTransfer.instance.battleWon) // if the battle was lost, reset to level block to first option states
            {
                Debug.Log("Battle in " + levelData[i].name + "Was Lost || Reseting level");
                levelData[i].firstTimeOpen = true;
            }
            else
            {
                levelData[i].firstTimeOpen = hasBeenPlayed[i];
            }
        }

        for (int i = 0; i < treasureLevels.Length; i++) // fixes treasure levels
        {
            if(treasureWasClaimed == null)
            {
                Debug.Log("No Treasure levels were stored");
                return;
            }
            
            treasureLevels[i].itemsHaveBeenAdded = treasureWasClaimed[i];

        }
    }


}
