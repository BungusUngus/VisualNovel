using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ButtonEvent : MonoBehaviour
{
    //what the button will display to the user
    public Text buttonDisplayText;

    //so we can change pages on click
    public PageManager pageManager;

    //what we should do when we click
    public string action;

    //what number or item or other thing to use
    public string key;

    //enable us to easily set up a new button
    public void Initialise(string action, string key, string label, PageManager pageManager)
    {
        this.action = action;
        this.key = key;
        this.pageManager = pageManager;

        buttonDisplayText = GetComponentInChildren<Text>();
        buttonDisplayText.text = label;
    }

    public void Event()
    {
        switch (action)
        {
            case "goto":
                int pageNumber = int.Parse(key);
                pageManager.LoadPage(pageNumber);
                break;

            case "collect":
                Item item = Enum.Parse<Item>(key);
                pageManager.inventory.Collect(item);

                break;
            default:
                Debug.LogWarning($"The button {this.name} failed to act, with action {action} and key {key}");
                break;

        }
    }
}
