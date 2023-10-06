using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{

    [HideInInspector]
    public string objectID;

    public bool destroyOnHomeMenu; // check if you want to destroy object when entering the home reason (ie deletes game data to start a new)

    private void Awake()
    {

        objectID = name + transform.position.ToString() + transform.eulerAngles.ToString(); //Give the scripted object an ID to check if there is duplicates in scene
    }


    void Start()
    {

        for (int i = 0; i < Object.FindObjectsOfType<DontDestroy>().Length; i++)
        {
            if(Object.FindObjectsOfType<DontDestroy>()[i] != this)
            {
                if(Object.FindObjectsOfType<DontDestroy>()[i].objectID == objectID) // if there is a duplicate, Delete it
                {
                    Destroy(gameObject);
                }
            }
        }

        DontDestroyOnLoad(gameObject);

    }

    private void Update()
    {
        // check to see if the current scene is Home Menu and if the object should be destroyed there (Delete Saved Data);
        if (destroyOnHomeMenu == true && SceneManager.GetActiveScene().name == "Home Menu")
        {
            Debug.Log("Destroying Game Data");
            Destroy(gameObject);
        }
    }

}
