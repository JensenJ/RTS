using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropoff : Interactable {

    public Item item;

    public override void Interact()
    {
        base.Interact();

        Dropoff();
    }
    void Dropoff()
    {
        

        Debug.Log("Dropping Off " + item.name);
        bool wasDroppedOff = Inventory.instance.Remove(item);
    }


}