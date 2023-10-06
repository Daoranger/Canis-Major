using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAdder : MonoBehaviour
{
    public ItemCreator item;


    public void AddItem()
    {

        //Debug.Log("Adding " + item.name);
        Inventory.instance.Add(item);
    }

    public void RemoveItem()
    {
        //Debug.Log("Removing " + item.name);
        Inventory.instance.Remove(item);

    }

}
