using UnityEngine;

public class InventoryController : MonoBehaviour {
  [field: SerializeField]
  public GenericDictionary<string, GameObject> ItemNameToPrefab { get; private set; }

  Inventory _inventoryManager;

  void Start() {
    _inventoryManager = FindObjectOfType<Inventory>();
    _inventoryManager.OnAddToInventory += OnAddToInventoryEventHandler;
  }

  void OnAddToInventoryEventHandler(object sender, AddToInventoryEventArgs args) {
    if (ItemNameToPrefab.TryGetValue(args.ItemName, out GameObject prefab)) {

    }
  }
}
