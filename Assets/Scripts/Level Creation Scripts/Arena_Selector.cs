using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arena_Selector : MonoBehaviour
{

    public LevelSaveData parentObject;

    public LevelData level;
    public GameObject highlight;
    public GameObject levelPlayedOutline;


    public bool blockedOut = false; // checks to see if level is locked
    
    private bool onTile = false;

    

    private Vector3 scaleChange = new Vector3(0.05f, 0.05f, 0);

    private void Start()
    {
        parentObject = transform.parent.GetComponent<LevelSaveData>();
        
        
    }

    //Commands to check if mouse is on top of block then highlight
    private void OnMouseEnter() // mouse enters block area
    {
        if (!blockedOut)
        {
            highlight.SetActive(true);
            onTile = true;
            this.transform.localScale += scaleChange; // makes bigger
        }

    }

    private void OnMouseExit() // mouse exits block area
    {
        if (!blockedOut)
        {
        highlight.SetActive(false);
        onTile = false;
        this.transform.localScale -= scaleChange; // makes smaller
        }

    }

    private void Update()
    {
        if (!blockedOut)
        {
            if (onTile && Input.GetMouseButtonDown(0)) // left Click | Only do if on the block area
            {
                Debug.Log("Block Activated");

                

                
                level.loadLevel();                  // starts changing scene
                level.firstTimeOpen = false;        // changes level to play 2nd portion (Only change on a win)
                parentObject.SaveData();
            }
            if (!level.firstTimeOpen && !levelPlayedOutline.activeSelf)
            {
                levelPlayedOutline.SetActive(true);
            }
        }
    }

}
