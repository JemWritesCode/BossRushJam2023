using DG.Tweening;

using UI.ThreeDimensional;

using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour {
  [field: SerializeField, Header("Render")]
  public UIObject3D PrefabRender { get; private set; }

  [field: SerializeField]
  public UIObject3DImage PrefabRenderImage { get; private set; }

  [field: SerializeField, Header("Decoration")]
  public Image ItemSlotFrame { get; private set; }

  [field: SerializeField]
  public Color FrameEmptyColor { get; private set; } = new(1f, 1f, 1f, 0.5f);

  [field: SerializeField]
  public Color FrameHasItemColor { get; private set; } = Color.yellow;

  Color _renderImageOriginalColor;

  void Awake() {
    _renderImageOriginalColor = PrefabRenderImage.color;
    PrefabRenderImage.color = _renderImageOriginalColor.SetAlpha(0f);
    ItemSlotFrame.color = FrameEmptyColor;
  }

  public void SetSlotPrefab(GameObject sourcePrefab) {
    PrefabRenderImage.DOColor(_renderImageOriginalColor.SetAlpha(1f), 1f);
    PrefabRender.ObjectPrefab = sourcePrefab.transform;
    PrefabRender.TargetRotation = sourcePrefab.transform.rotation.eulerAngles;

    ItemSlotFrame.DOColor(FrameHasItemColor, 1f);
  }

  public void ClearSlotPrefab() {
    PrefabRenderImage
        .DOColor(_renderImageOriginalColor.SetAlpha(0f), 1f)
        .OnComplete(() => { PrefabRender.ObjectPrefab = default; });
    
    ItemSlotFrame.DOColor(FrameEmptyColor, 1f);
  }
}
