using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public event EventHandler<AddToInventoryEventArgs> OnAddToInventory;

    public string[] inventory = { "", "", "" };
    public string weapon = "";

    public Dictionary<string, string> weaponRecipes;

    public void Start()
    {
        weaponRecipes = new Dictionary<string, string>();
        //weaponRecipes.Add("boltboltbolt", "");
        //weaponRecipes.Add("boltboltgear", "");
        //weaponRecipes.Add("boltboltpipe", "");
        //weaponRecipes.Add("geargeargear", "");
        //weaponRecipes.Add("boltgeargear", "");
        weaponRecipes.Add("geargearpipe", "bomb");
        //weaponRecipes.Add("pipepipepipe", "");
        weaponRecipes.Add("boltpipepipe", "shotgun");
        //weaponRecipes.Add("gearpipepipe", "");
    }

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
        //JEMTODO delay or animation to show it's making invention (probably like 2 seconds)
        string result;
        Array.Sort(inventory);
        if(weaponRecipes.TryGetValue(inventory[0] + inventory[1] + inventory[2], out result))
        {
            Debug.Log("You crafted a " + result + "!");
            //JEMTODO Set Player Weapon
        }
        else
        {
            Debug.Log("Failed Invention!");
            //JEMTODO Tell Player Failed Invention 
            // Default "FAILED" in the logo box
            // Timer should be super fast for this so they can collect items again
        }
    }
}

public class AddToInventoryEventArgs : EventArgs
    {
        public int InventorySlot { get; set; }
        public string ItemName { get; set; }
    }
