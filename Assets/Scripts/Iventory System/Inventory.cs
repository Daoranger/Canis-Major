using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public GameObject itemPrefab;

    public List<ItemCreator> items = new List<ItemCreator>();

    #region Singleton

    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {

            Debug.LogWarning("More than one instance of Inventory Found!");
            return;
        }
        instance = this;



    }

    #endregion


    public void Add (ItemCreator item)
    {
        for (int i = 0; i < items.Count; i++) // check to see if item is already in inventory list
        {
            if (items[i].name.Contains(item.name))
            {
                Debug.Log("Adding 1 to " + item.name);
                item.amount++;
                return;
            }
        }
        Debug.Log("Item " + item + " added to inventory");
        items.Add(item);

        item.amount = 1; // Resets amount to 1 on spawn                                                 << (Temporary or Permanent)
        GameObject temp = Instantiate(itemPrefab, transform.parent); // creates new item ui

        temp.GetComponent<ItemDisplay>().item = item; // sets new item to display selected itemDisplay
        temp.transform.SetParent(gameObject.transform);

    }


    public void Remove (ItemCreator item)
    {
        for (int i = 0; i < items.Count; i++) // check to see if item is already in inventory list      << (Temporary or Permanent)
        {
            if (items[i].name.Contains(item.name) && item.amount > 1) // only minus if there is more than 1 in the inventory
            {
                Debug.Log("Removing 1 to " + item.name);
                item.amount--;
                return;
            }
        }
        item.amount--;
        Debug.Log("Removing " + item.name + " from the list");
        items.Remove(item);
    }

    
}
