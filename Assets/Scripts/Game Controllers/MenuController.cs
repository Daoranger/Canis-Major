
using UnityEngine;
public class MenuController : MonoBehaviour
{



    [SerializeField] private GameObject menuScreen;

    public bool differentUIOpen = false;
    public bool menuIsOpen = false;
    

    // Button Logic (Needed so buttons can change the script for the better)
    public void returnToGameButton()
    {
        menuIsOpen = false;
    }
    public void differentUIIsOpen()
    {
        differentUIOpen = true;
    }
    public void differentUIIsClosed() 
    {
        differentUIOpen = false;
    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !differentUIOpen) // opens/closes the menu screen if no other menus are open
        {
            if (!menuIsOpen) // Open
            {
                menuScreen.SetActive(true);
                menuIsOpen = true;
                Debug.Log("Opening " + menuScreen.name);
            }
            else // Close
            {
                menuScreen.SetActive(false);
                menuIsOpen = false;
                Debug.Log("Closing " + menuScreen.name);
            }
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && menuIsOpen) // Closes all other menus open but not the menu screen
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                Debug.Log("child: " + child.name + " | i = " + i);

                if (child.name != menuScreen.name && differentUIOpen) 
                {
                    child.gameObject.SetActive(false);
                    Debug.Log("Closing: " + child.name);
                }
            }
            differentUIOpen = false;
        }
    }
}
