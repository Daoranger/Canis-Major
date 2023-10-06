using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


[RequireComponent(typeof(Image))]
public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    public TabGroup tabGroup;

    public Image background; // Used to apply button Effects to 

    public bool startsSelected;

    // Button Simulator

    public void OnPointerClick(PointerEventData eventData)
    {
        tabGroup.OnTabSelected(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tabGroup.OnTabEnter(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tabGroup.OnTabExit(this);
    }


    private void Start()
    {
        background = GetComponent <Image>();
        tabGroup.Subscribe(this); // adds Button to index
        
        if (startsSelected) // Makes it so tab that is already open is in selected color
        {
            tabGroup.OnTabSelected(this);
        }
    }

}
