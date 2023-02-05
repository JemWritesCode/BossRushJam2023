using System.Collections.Generic;

using UnityEngine;

public class InventoryController : MonoBehaviour {
  [field: SerializeField]
  public GenericDictionary<string, GameObject> ItemNameToPrefab { get; private set; }

  [field: SerializeField]
  public List<ItemSlot> ItemSlots { get; private set; }

  Inventory _inventoryManager;

  void Start() {
    _inventoryManager = FindObjectOfType<Inventory>();
    _inventoryManager.OnAddToInventory += OnAddToInventoryEventHandler;
  }

  void OnAddToInventoryEventHandler(object sender, AddToInventoryEventArgs args) {
    Debug.Log($"Added item: {args.ItemName}, slot: {args.InventorySlot}");
    if (args.InventorySlot < ItemSlots.Count
        && ItemNameToPrefab.TryGetValue(args.ItemName, out GameObject sourcePrefab)) {
      ItemSlots[args.InventorySlot].SetSlotPrefab(sourcePrefab);
    }
  }
}
