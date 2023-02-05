using System;

using UnityEngine;

public class Inventory : MonoBehaviour
{
    public event EventHandler<AddToInventoryEventArgs> OnAddToInventory;

    public string[] inventory = { "", "", "" };

    public void AddToInventory(string item)
    {
        for(int i = 0; i < inventory.Length; i++)
        {
            if(string.IsNullOrEmpty(inventory[i]))
            {
                inventory[i] = item;
                OnAddToInventory?.Invoke(this, new() { InventorySlot = i, ItemName = item });
                return;
            }
        }
    }
}

public class AddToInventoryEventArgs : EventArgs {
  public int InventorySlot { get; set; }
  public string ItemName { get; set; }
}