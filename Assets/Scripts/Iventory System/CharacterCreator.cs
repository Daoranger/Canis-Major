using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Inventory/Character Description")]
public class CharacterCreator : ScriptableObject
{
    new public string name = "Insert Name Here";

    public Sprite Image;

    [TextArea(4, 20)]
    public string description = "Add Description";

}
