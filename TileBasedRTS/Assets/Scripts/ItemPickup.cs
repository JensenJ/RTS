﻿using UnityEngine;

public class ItemPickup : Interactable {

    public Item item;
    public int Resources = 10;

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }
    void PickUp()
    {
        
        
        Debug.Log("Picking Up " + item.name);
        bool wasPickedUp = Inventory.instance.Add(item);
        if (wasPickedUp)
        {
            //Destroy(gameObject);
        }
    }


}
