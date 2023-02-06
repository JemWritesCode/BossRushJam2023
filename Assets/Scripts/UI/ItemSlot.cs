using UI.ThreeDimensional;

using UnityEngine;

public class ItemSlot : MonoBehaviour {
  [field: SerializeField]
  public UIObject3D PrefabRender { get; private set; }

  [field: SerializeField]
  public UIObject3DImage PrefabRenderImage { get; private set; }

  public void SetSlotPrefab(GameObject sourcePrefab) {
    PrefabRenderImage.color = PrefabRenderImage.color.SetAlpha(1f);
    PrefabRender.ObjectPrefab = sourcePrefab.transform;
    PrefabRender.TargetRotation = sourcePrefab.transform.rotation.eulerAngles;
  }

  public void ClearSlotPrefab() {
    PrefabRenderImage.color = PrefabRenderImage.color.SetAlpha(0f);
    PrefabRender.ObjectPrefab = default;
  }
}
