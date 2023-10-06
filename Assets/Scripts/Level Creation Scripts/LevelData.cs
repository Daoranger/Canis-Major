using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{

    public levelLoad firstLevelPortion = new levelLoad();
    public levelLoad secondLevelPortion = new levelLoad();

    public bool firstTimeOpen = true;
    public bool levelInPlay = false;
    public void loadLevel()
    {

        if (firstTimeOpen)
        {
            DataSceneTransfer.instance.add(firstLevelPortion.enemyCharacter, firstLevelPortion.dialogueScene); // load first version of level
            firstTimeOpen = false;
            levelInPlay = true;
        }
        else
        {
            DataSceneTransfer.instance.add(secondLevelPortion.enemyCharacter, secondLevelPortion.dialogueScene); // load second version of level
            levelInPlay = true;
        }

    }




    [System.Serializable]
    public struct levelLoad
    {
        public EnemyCreator enemyCharacter;
        public StoryScene dialogueScene;
    }


}
