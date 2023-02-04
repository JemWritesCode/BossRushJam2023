using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public GameObject pickupEffect;
    public string pickupType;

    public GameObject inventoryManager;
    private Inventory inventoryScript;

    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryManager");
        inventoryScript = inventoryManager.GetComponent<Inventory>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }

    private void Pickup(Collider player)
    {
        GameObject pickupFX = Instantiate(pickupEffect, transform.position, transform.rotation);
        Destroy(pickupFX, 1f);

        inventoryScript.AddToInventory(pickupType);
        pickupEffect.SetActive(true);
        Destroy(gameObject);
    }
}
