using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemDisplay : MonoBehaviour
{

    public ItemCreator item;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI flavorText;

    public Image artworkImage;

    public TextMeshProUGUI value;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI amount;
    // not yet added / plan to add

    //public TextMeshProUGUI cost; 


    void Start()
    {
        nameText.text = item.name;
        gameObject.name = item.name;


        flavorText.text = item.flavorText;
        descriptionText.text = item.description;

        artworkImage.sprite = item.artwork;

        gameObject.tag = item.itemTag.ToString();

        // creating different looks depending on if item is ment to be a health | damage | defence value

        if (gameObject.tag == "Health")
        {
            value.text = "Healing: " + item.value.ToString();
            value.color = Color.green;
        }
        else if (gameObject.tag == "Damage")
        {
            value.text = "Damage: " + item.value.ToString();
            value.color = Color.red;
        }
        else
        {
            value.text = "Defence: " + item.value.ToString();
            value.color = Color.gray;
        }
        amount.text = "x" + item.amount.ToString();
    }
    private void Update()
    {
        amount.text = "x" + item.amount.ToString();

        if (item.amount <= 0)
        {
            Destroy(gameObject);
        }
    }
}
