using DG.Tweening;

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
    Sequence sequence = DOTween.Sequence();

    Color frameColor = args.InventionSuccess ? Color.green : Color.red;

    for (int i = 0; i < ItemSlots.Count; i++) {
      ItemSlot itemSlot = ItemSlots[i];

      sequence.Insert(
          i * 0.25f, itemSlot.ItemSlotFrame.DOColor(frameColor, 1f));

      if (args.InventionSuccess) {
        sequence.Insert(i * 0.25f, itemSlot.transform.DOPunchScale(Vector3.one * 0.1f, 1.5f));
      } else {
        sequence.Insert(1f + (i * 0.25f), itemSlot.PrefabRenderImage.DOColor(Color.black, 1f));
        sequence.InsertCallback(3f, () => itemSlot.ClearSlotPrefab());
      }
    }
  }
}
