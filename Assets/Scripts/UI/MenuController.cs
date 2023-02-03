using DG.Tweening;

using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class MenuController : MonoBehaviour {
  [field: SerializeField]
  public GameObject MenuRoot { get; private set; }

  [field: SerializeField]
  public PostProcessVolume MenuCameraEffects { get; private set; }

  GameObject _cameraController;
  StarterAssets.StarterAssetsInputs _inputController;

  ColorGrading _colorGradingEffect;
  DepthOfField _depthOfFieldEffect;

  void Start() {
    _cameraController = GameObject.FindGameObjectWithTag("CameraController");
    _inputController = FindObjectOfType<StarterAssets.StarterAssetsInputs>();

    _colorGradingEffect = MenuCameraEffects.profile.GetSetting<ColorGrading>();
    _depthOfFieldEffect = MenuCameraEffects.profile.GetSetting<DepthOfField>();

    ToggleMenu(toggleOn: false);
  }

  void Update() {
    if (Input.GetKeyDown(KeyCode.Escape)) {
      ToggleMenu(!MenuRoot.activeSelf);
    }
  }

  public void ToggleMenu(bool toggleOn) {
    MenuRoot.SetActive(toggleOn);
    _cameraController.SetActive(!toggleOn);

    _inputController.cursorInputForLook = !toggleOn;
    _inputController.cursorLocked = !toggleOn;

    DOTween
        .To(() =>
              _colorGradingEffect.saturation.value,
              x => _colorGradingEffect.saturation.value = x,
              toggleOn ? -100f : 0f,
              2f)
        .SetUpdate(true)
        .OnStart(() => _depthOfFieldEffect.enabled.value = toggleOn);

    DOTween.To(() => Time.timeScale, x => Time.timeScale = x, toggleOn ? 0f : 1f, 2f).SetUpdate(true);
  }
}
