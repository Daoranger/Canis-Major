using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureItemAdder : MonoBehaviour
{
    #region Singleton

    public static TreasureItemAdder instance;

    private void Awake()
    {
        if (instance != null)
        {

            Debug.LogWarning("More than one instance of TreasureItemAdder Found on " + this.name);
            return;
        }
        instance = this;

    }

    #endregion

    public GameObject prefab;

    public void AddItem(ItemCreator item)
    {

        GameObject temp = Instantiate(prefab, transform.parent); // creates Item at Parent object's Position
        temp.GetComponent<TreasureItemDisplay>().item = item; // sets item display
        temp.transform.SetParent(gameObject.transform); // sets parent
    }

    public void ClearItems()
    {
        for (int i = 0; i < transform.childCount; i++) // runs for every child
        {
            Destroy(transform.GetChild(i).gameObject); // destroys child
        }
    }
}
