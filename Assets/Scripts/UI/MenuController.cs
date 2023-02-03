using DG.Tweening;

using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class MenuController : MonoBehaviour {
  [field: SerializeField]
  public GameObject MenuRoot { get; private set; }

  [field: SerializeField]
  public PostProcessVolume MenuCameraEffects { get; private set; }

  GameObject _cameraController;
  ColorGrading _colorGradingEffect;
  DepthOfField _depthOfFieldEffect;

  StarterAssets.StarterAssetsInputs _inputController;

  void Start() {
    _cameraController = GameObject.FindGameObjectWithTag("CameraController");
    _colorGradingEffect = MenuCameraEffects.profile.GetSetting<ColorGrading>();
    _depthOfFieldEffect = MenuCameraEffects.profile.GetSetting<DepthOfField>();
    _inputController = FindObjectOfType<StarterAssets.StarterAssetsInputs>();

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

    _inputController.cursorInputForLook = toggleOn ? false : true;
    _inputController.cursorLocked = toggleOn ? false : true;

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
