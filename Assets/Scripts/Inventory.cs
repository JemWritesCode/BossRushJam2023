using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public string[] inventory = { "", "", "" };

    public void AddToInventory(string item)
    {
        for(int i = 0; i < inventory.Length; i++)
        {
            if(string.IsNullOrEmpty(inventory[i]))
            {
                inventory[i] = item;
                return;
            }
        }
    }
}
