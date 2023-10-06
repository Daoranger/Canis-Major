using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Create Enemy")]
public class EnemyCreator : ScriptableObject
{
    
    new public string name = "New Name";
    public Sprite characterImage;
    public int health = 100;
    public int damage = 10;

}
