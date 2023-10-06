using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleInventoryRetrieval : MonoBehaviour
{
    public GameObject itemPrefab;
    public List<ItemCreator> itemList;


    private void Start()
    {
        if(Inventory.instance == null) // check if inventory is in scene
        {
            Debug.LogWarning("Inventory instance not found || Skipping inventory process");
        }

        itemList = Inventory.instance.items;

        foreach (ItemCreator item in itemList)
        {
            if (item.itemTag.ToString() == "Health") // Battle Inventory will only display Health potions
            {
                GameObject temp = Instantiate(itemPrefab, transform.parent); // creates new item ui

                temp.GetComponent<BattleItemDisplay>().item = item; // sets new item to display selected itemDisplay
                temp.transform.SetParent(gameObject.transform); // moves item to a child of gameObject with script
            }
        }        
    }
}
