using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons; // Buttons are placed under the TabGroup GameObject

    public Color tabIdle = Color.white;
    public Color tabHover = Color.white;
    public Color tabActive = Color.white;

    public List<GameObject> infoPanels; // Panels Are stored in their own location for Organization

    public TabButton selectedTab;




    // Adds Buttons to List
    public void Subscribe(TabButton button)
    {
        if (tabButtons == null)
        {
            tabButtons = new List<TabButton>();
        }


        tabButtons.Add(button);
    }


    // When Mouse is Over Button
    public void OnTabEnter(TabButton button)
    {
        ResetTabs();
        if(selectedTab == null || button != selectedTab) // Does not reapply to already selected buttons
        {
            button.background.color = tabHover;
        }
    }


    // When Mouse leaves button
    public void OnTabExit(TabButton button)
    {
        ResetTabs();
    }


    // When Mouse selects button
    public void OnTabSelected(TabButton button)
    {
        selectedTab = button;
        ResetTabs();
        button.background.color = tabActive;
        int index = button.transform.GetSiblingIndex();

        for (int i = 0; i < infoPanels.Count; i++) // Changes to new Info Panel (Make Sure Panels are in same order as Tabs)
        {

            if (i == index)
            {
                infoPanels[i].SetActive(true);
            }
            else
            {
                infoPanels[i].SetActive(false);
            }
        }
    }


    // When Mouse Selects a new button
    public void ResetTabs()
    {
        foreach (TabButton button in tabButtons) // Sets all buttons but the pressed button back to default
        {
            if(selectedTab != null && button == selectedTab) { continue; }
            button.background.color = tabIdle;
        }
    }
}
