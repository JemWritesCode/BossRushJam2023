using UI.ThreeDimensional;

using UnityEngine;

public class ItemSlot : MonoBehaviour {
  [field: SerializeField]
  public UIObject3D PrefabRender { get; private set; }

  [field: SerializeField]
  public RotateUIObject3D PrefabRotate { get; private set; }

  public void SetSlotPrefab(GameObject sourcePrefab) {
    PrefabRender.ObjectPrefab = sourcePrefab.transform;
    PrefabRender.TargetRotation = sourcePrefab.transform.rotation.eulerAngles;
  }

  public void ClearSlotPrefab() {
    PrefabRender.ObjectPrefab = default;
  }
}
