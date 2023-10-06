using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private GameObject[] levelBranch; // all Objects down this branch


    // turns on black mask and deactivates Arena_Selector component on the object (Object must have Arena_Selector)
    private void deactivateLevels() 
    {
        foreach(GameObject level in levelBranch)
        {
            GameObject blackOut = level.transform.GetChild(0).gameObject; // Gets the first child in the hierarchy of the prefab (make sure to put BlackOut tile in first position)

            if (level.GetComponent<Arena_Selector>().blockedOut == true)
            {
                blackOut.SetActive(true); // turns on BlackOut (First Child)
                level.GetComponent<Arena_Selector>().blockedOut = true; // Turns off Arena_Selector component
            }
        }
    }


    private void Start()
    {
        deactivateLevels(); 

    }

    private void Update()
    {
        


        // ## checks to see if a block has been activated and turns on the next block ahead of it ##
        for (int i = 1; i < levelBranch.Length; i++)
        {
            bool levelArena = levelBranch[i - 1].GetComponent<LevelData>().firstTimeOpen; // grabs the Level Data of previous Level in branch to see if it has been played
            GameObject blackOut = levelBranch[i].transform.GetChild(0).gameObject; // grabs the blackOut tile of hidden level (Level block must have BlackOut tile in first position)

            if (!levelArena && levelBranch[i].GetComponent<Arena_Selector>().blockedOut == true) // checks to see if previous level has been played and if the next level is still locked
            {
                StartCoroutine(FadeOut(blackOut)); // remove lock
                levelBranch[i].GetComponent<Arena_Selector>().blockedOut = false; // unlocks Arena_Selector Code
            }
        }
    }

    IEnumerator FadeOut(GameObject objectColor) // does a fade out animation on object
    {


        for (float f = 1; f >= 0; f -= 0.05f)
        {

            if (objectColor.transform.childCount > 0) // fades both object and child image (Only fades object and first child colors)
            {
                
                Color fade = objectColor.GetComponent<SpriteRenderer>().color;
                Color childFade = objectColor.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color; // Gets first child's color
                childFade.a = f;
                fade.a = f;
                objectColor.GetComponent<SpriteRenderer>().color = fade;
                objectColor.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = childFade; // changes child color

                

                yield return new WaitForSeconds(0.05f);
            }
            else // Fades Only the Object
            {
                Debug.Log("No child");
                Color fade = objectColor.GetComponent<SpriteRenderer>().color;
                fade.a = f;
                objectColor.GetComponent<SpriteRenderer>().color = fade;

                yield return new WaitForSeconds(0.05f);
            }
        }
        objectColor.SetActive(false);
    }
}
