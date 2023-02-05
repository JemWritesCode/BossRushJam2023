using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public event EventHandler<AddToInventoryEventArgs> OnAddToInventory;

    public string[] inventory = { "", "", "" };
    public Dictionary<string, string> weaponRecipes;

    public void AddToInventory(string item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (string.IsNullOrEmpty(inventory[i]))
            {
                inventory[i] = item;
                if (i == 2)
                {
                    MakeInvention();
                }
                OnAddToInventory?.Invoke(this, new() { InventorySlot = i, ItemName = item });
                return;
            }
        }
    }

    private void MakeInvention()
    {
        // delay or animation to show it's making invention (probably like 2 seconds)
        // depending on what the items are make a certain weapon
        //ideally this list of what items make which weapons is JSON? 
        // or maybe something that can be easily edited it in the Unity Editor
        //dictionary? [key = geargeargear, value = weaponMade]


        // whatever I get just sort it before I compare it to the recipes (also sorted? I can probably just sort this once before on the data set itself)
        // then I'll always get the same comparison
    }
}

public class AddToInventoryEventArgs : EventArgs
    {
        public int InventorySlot { get; set; }
        public string ItemName { get; set; }
    }
