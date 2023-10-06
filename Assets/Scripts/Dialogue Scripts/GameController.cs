using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public StoryScene currentScene;
    public BottomBarController bottomBar;
    public Image background;
    void Start()
    {
        if (DataSceneTransfer.instance != null) // only try to change current scene to DataScene if there is a DataSceneTransfer in the Scene
        {
            currentScene = DataSceneTransfer.instance.scene;
        }
        background.sprite = currentScene.background;    
        bottomBar.PlayScene(currentScene);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (bottomBar.IsCompleted())
            {
                if (bottomBar.IsLastSentence())
                {
                    if (currentScene.nextScene != null)
                    {
                        currentScene = currentScene.nextScene;
                        bottomBar.PlayScene(currentScene);
                        background.sprite = currentScene.background;
                    }
                    else
                    {
                        if (DataSceneTransfer.instance != null)
                        {
                            if (DataSceneTransfer.instance.enemy != null)
                            {
                                DataSceneTransfer.instance.loadBattleScene(); // loading Battle Scene from LevelData
                            }
                            else
                            {
                               SceneManager.LoadScene("Level Creator"); // load level again if there is no enemy
                            }
                        }
                        else
                        {
                            SceneManager.LoadScene("TownSquare"); // if there are no scenes left and no LevelData, game will load GuildHouse
                        }
                    }
                    
                }
                else
                {
                    bottomBar.PlayNextSentence();
                }
            }
        }
    }
}
