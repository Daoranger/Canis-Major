using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class ItemCreator : ScriptableObject
{

    new public string name = "No Name";
    [TextArea(2, 15)]
    public string flavorText = "Flaver Text";

    public Sprite artwork;

    public enum tagChoices { Health, Damage, Defence }
    public tagChoices itemTag;

    public int value = 0;
    public int cost = 0;
    public int amount = 1;

    [TextArea(4,20)]
    public string description = "Empty";
}
