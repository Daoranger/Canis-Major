using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakeUp : MonoBehaviour
{
    public GameObject[] turnOffAndOn;

    // ok so basically if one of the singleton scripts loads into the game as (not Active) it
    // will act as not being in the game, but once you activate and deactivate the object
    // with the script, it now, for some reason works. My sanity is fading.
    private void Awake()
    {
        foreach (GameObject item in turnOffAndOn)
        {
            item.SetActive(true);
            item.SetActive(false);
        }
    }
}
