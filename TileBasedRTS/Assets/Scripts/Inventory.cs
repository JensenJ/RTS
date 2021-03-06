﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of inventory found!");
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 2;

    public List<Item> items = new List<Item>();

    public bool Add (Item item)
    {
        if (!item.isDefaultItem)
        {
            if(items.Count >= space)
            {
                Debug.Log("Not enough room");
                return false;
            }
            items.Add(item);
            if(onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }   
        return true;
    }
    public bool Remove(Item item)
    {
        if (!item.isDefaultItem)
        {
            if(items.Count == 50) //placeholder if statement for when stockple storage is implemented
            {
                Debug.Log("Not enough room in stockpile");
                return false;
            }
            items.Remove(item);
            if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
        }
        return true;
    }

}
