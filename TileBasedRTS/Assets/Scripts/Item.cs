﻿using UnityEngine;

public class Item : ScriptableObject{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }
}