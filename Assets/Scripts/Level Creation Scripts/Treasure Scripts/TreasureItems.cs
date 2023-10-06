using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureItems : MonoBehaviour
{
     private Arena_Selector arena;
     private LevelData data;

    private LevelSaveData levelSave;

    public GameObject TreasureCanvas;

    [SerializeField] private AddItem[] itemStruct;

    public bool itemsHaveBeenAdded = false;

    private void Start()
    {
        levelSave = transform.parent.GetComponent<LevelSaveData>();
        arena = GetComponent<Arena_Selector>();
        data = GetComponent<LevelData>();
    }

    private void Update()
    {
        if(itemStruct == null) //nothing has been added to teasure slot
        {
            Debug.LogError(name + " does not have item rewards added");
            return; // stops program on error
        }


        // Only Runs Script on Level's first time opening and if the level is not blocked
        // and will only run once
        if (!arena.blockedOut && !itemsHaveBeenAdded && data.levelInPlay) 
        {
            TreasureCanvas.SetActive(true);
            foreach (AddItem item in itemStruct) //goes through each item being added
            {
                if(item.item == null) // checks to make sure there is an item in every slot
                {
                    Debug.LogError(name + " is missing an item slot in its array");
                    return; 
                }
                else if (Inventory.instance == null)
                {
                    Debug.LogError("Inventory Instance Missing");
                    return;
                }

                for (int i = 0; i < item.amount; i++) //adds item based on how many are being added
                {
                    Inventory.instance.Add(item.item);
                    TreasureItemAdder.instance.AddItem(item.item);
                }
            }
            itemsHaveBeenAdded = true;
            levelSave.SaveData();
            Debug.Log("Data Saved");
        }
    }


    [System.Serializable]
    public struct AddItem 
    {

        public ItemCreator item;
        public int amount;

    }

}
