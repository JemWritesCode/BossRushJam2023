using System.Collections.Generic;

using UnityEngine;

public class InventoryPanelController : MonoBehaviour {
  [field: SerializeField]
  public GenericDictionary<string, GameObject> ItemNameToPrefab { get; private set; }

  [field: SerializeField]
  public List<ItemSlot> ItemSlots { get; private set; }

  Inventory _inventoryManager;

  void Start() {
    _inventoryManager = FindObjectOfType<Inventory>();
    _inventoryManager.OnAddToInventory += OnAddToInventoryEventHandler;
    _inventoryManager.OnMakeInvention += OnMakeInventionEventHandler;
  }

  void OnAddToInventoryEventHandler(object sender, AddToInventoryEventArgs args) {
    if (args.InventorySlot < ItemSlots.Count
        && ItemNameToPrefab.TryGetValue(args.ItemName, out GameObject sourcePrefab)) {
      ItemSlots[args.InventorySlot].SetSlotPrefab(sourcePrefab);
    }
  }

  void OnMakeInventionEventHandler(object sender, MakeInventionEventArgs args) {
    foreach (ItemSlot itemSlot in ItemSlots) {
      itemSlot.ClearSlotPrefab();
    }
  }
}
