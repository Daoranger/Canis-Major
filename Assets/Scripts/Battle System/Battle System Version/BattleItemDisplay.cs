using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleItemDisplay : MonoBehaviour
{

    public ItemCreator item;

    public TextMeshProUGUI itemName;

    public Image itemImage;

    public TextMeshProUGUI itemStat;
    public TextMeshProUGUI itemAmount;


    void Start()
    {
        itemName.text = item.name;
        itemImage.sprite = item.artwork;
        itemAmount.text = "x" + item.amount.ToString();

        gameObject.tag = item.itemTag.ToString();
        // creating different looks depending on if item is ment to be a health | damage | defence value

        if (gameObject.tag == "Health")
        {
            itemStat.text = "Healing: " + item.value.ToString();
            itemStat.color = Color.green;
        }
        else if (gameObject.tag == "Damage")
        {
            itemStat.text = "Damage: " + item.value.ToString();
            itemStat.color = Color.red;
        }
        else
        {
            itemStat.text = "Defence: " + item.value.ToString();
            itemStat.color = Color.gray;
        }

    }


    public void useItem()
    {

        for (int i = 0; i < Inventory.instance.items.Count; i++) // check to see if item is already in inventory list
        {
            if (Inventory.instance.items[i].name.Contains(item.name))
            {
                Debug.Log("Removing 1 " + item.name + " from inventory");
                
                if(PlayerHealth.instance == null || Inventory.instance == null) // Debug for when singletons are not loaded into scene
                {
                    Debug.LogError("Missing Playerhealth or Inventory");
                    return;
                }

                PlayerHealth.instance.TakeDamage(-item.value);
                Inventory.instance.Remove(item);
                
                return;
            }
        }
    }


    private void Update()
    {
        itemAmount.text = "x" + item.amount.ToString();

        if (item.amount <= 0)
        {
            Inventory.instance.Remove(item);
            Destroy(gameObject);
        }
    }
}
