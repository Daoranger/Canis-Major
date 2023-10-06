using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TreasureItemDisplay : MonoBehaviour
{

    public ItemCreator item;

    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI itemName;


    private void Start()
    {
        itemImage.sprite = item.artwork;

        itemName.text = item.name;
    }

}
