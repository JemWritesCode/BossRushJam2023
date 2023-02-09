using DG.Tweening;

using UI.ThreeDimensional;

using UnityEngine;
using UnityEngine.UI;

public class InventionPanelController : MonoBehaviour {
  [field: SerializeField]
  public CanvasGroup InventionPanel { get; private set; }

  [field: SerializeField]
  public TMPro.TMP_Text InventionName { get; private set; }

  [field: SerializeField]
  public UIObject3D InventionRender { get; private set; }

  [field: SerializeField]
  public TMPro.TMP_Text DurabilityText { get; private set; }

  [field: SerializeField]
  public Slider DurabilityBar { get; private set; }

  Inventory _inventoryManager;

  void Awake() {
    InventionPanel.alpha = 0f;

    _inventoryManager = FindObjectOfType<Inventory>();
    _inventoryManager.OnMakeInvention += OnMakeInventionEventHandler;
  }

  void OnMakeInventionEventHandler(object sender, MakeInventionEventArgs args) {
    if (args.InventionSuccess) {
      InventionName.text = args.InventionName;

      DOTween.Sequence()
          .SetLink(InventionPanel.gameObject)
          .Insert(0.5f, InventionPanel.DOFade(1f, 1f))
          .Insert(0.5f, InventionPanel.transform.DOLocalMoveX(-30f, 1.5f).From(true));
    }
  }
}
