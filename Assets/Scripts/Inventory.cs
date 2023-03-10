using System;
using System.Collections.Generic;

using UnityEngine;

public class Inventory : MonoBehaviour
{
    public event EventHandler<AddToInventoryEventArgs> OnAddToInventory;
    public event EventHandler<MakeInventionEventArgs> OnMakeInvention;

    public string[] inventory = { "", "", "" };
    public string weapon = "";

    public Dictionary<string, string> weaponRecipes;

    public void Start()
    {
        weaponRecipes = new Dictionary<string, string>();
        //weaponRecipes.Add("boltboltbolt", "");
        //weaponRecipes.Add("boltboltgear", "");
        weaponRecipes.Add("boltboltpipe", "sword");
        //weaponRecipes.Add("geargeargear", "");
        //weaponRecipes.Add("boltgeargear", "");
        //weaponRecipes.Add("geargearpipe", "bomb");
        //weaponRecipes.Add("pipepipepipe", "");
        weaponRecipes.Add("boltpipepipe", "pistol");
        //weaponRecipes.Add("gearpipepipe", "");
    }

    public void AddToInventory(string item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (string.IsNullOrEmpty(inventory[i]))
            {
                OnAddToInventory?.Invoke(this, new() { InventorySlot = i, ItemName = item });
                inventory[i] = item;
                if (i == 2)
                {
                    MakeInvention();
                }
                return;
            }
        }
    }

    private void MakeInvention()
    {
        //JEMTODO delay or animation to show it's making invention (probably like 2 seconds)
        string result;
        Array.Sort(inventory);
        if(weaponRecipes.TryGetValue(inventory[0] + inventory[1] + inventory[2], out result))
        {
            Debug.Log("You crafted a " + result + "!");
            OnMakeInvention?.Invoke(this, new() { InventionSuccess = true, InventionName = result });
            //JEMTODO Set Player Weapon
        }
        else
        {
            Debug.Log("Failed Invention!");
            OnMakeInvention?.Invoke(this, new() { InventionSuccess = false, InventionName = string.Empty });
            //JEMTODO Tell Player Failed Invention 
            // Default "FAILED" in the logo box
            // Timer should be super fast for this so they can collect items again
            inventory[0] = string.Empty;
            inventory[1] = string.Empty;
            inventory[2] = string.Empty;
        }
    }
}

public class AddToInventoryEventArgs : EventArgs {
  public int InventorySlot { get; set; }
  public string ItemName { get; set; }
}

public class MakeInventionEventArgs : EventArgs {
  public bool InventionSuccess { get; set; }
  public string InventionName { get; set; }
}