using UI.ThreeDimensional;

using UnityEngine;
using UnityEngine.UI;

public class InventionPanelController : MonoBehaviour {
  [field: SerializeField]
  public GameObject InventionPanel { get; private set; }

  [field: SerializeField]
  public TMPro.TMP_Text InventionName { get; private set; }

  [field: SerializeField]
  public UIObject3D InventionRender { get; private set; }

  [field: SerializeField]
  public TMPro.TMP_Text DurabilityText { get; private set; }

  [field: SerializeField]
  public Slider DurabilityBar { get; private set; }
}
