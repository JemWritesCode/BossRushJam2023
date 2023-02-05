using UnityEngine;

public class InventoryController : MonoBehaviour {
  [field: SerializeField]
  public GenericDictionary<string, GameObject> ItemNameToPrefabMapping { get; private set; }

  Inventory _inventoryManager;

  void Start() {
    _inventoryManager = FindObjectOfType<Inventory>();
    _inventoryManager.OnAddToInventory += OnAddToInventoryEventHandler;
  }

  void OnAddToInventoryEventHandler(object sender, AddToInventoryEventArgs eventArgs) {

  }
}
