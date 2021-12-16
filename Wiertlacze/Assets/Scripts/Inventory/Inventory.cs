using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public Sprite[] spriteArray;
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory is running");
        }
        instance = this;
    }

    #endregion

    public delegate void onItemChanged();
    public onItemChanged onItemChangedCallback;
    
    public int space = 8;

    public List<Item> items = new List<Item>();

    public void Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("Cargo is Full.");
                return;
            }

            if (item.name == "Dirt")
                return;

            
            // Debug.Log("adding " + item.name + " to the inventory");
            items.Add(item);

            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }
    }

    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
