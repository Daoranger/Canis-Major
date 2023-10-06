using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{


    public void LoadTownScene()
    {
        Debug.Log("Loading TownSquare Scene");
        SceneManager.LoadScene("TownSquare");
    }

    public void QuitTheGame()
    {
        Application.Quit();
    }

    public void RestartScene()
    {
        Debug.Log("Reloading Scene...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Scene Reloaded");
    }

    public void LoadLevelScene()
    {
        Debug.Log("Loading Level Creator Scene");
        SceneManager.LoadScene("Level Creator");
    }

    public void LoadMainMenuScene()
    {
        Debug.Log("Loading Main Menu Scene");
        SceneManager.LoadScene("Home Menu");
    }

    public void LoadBeginningDialogueScene()
    {
        Debug.Log("Loading First Dialogue Scene (Visual Novel)");
        SceneManager.LoadScene("Visual Novel");
    }

}
