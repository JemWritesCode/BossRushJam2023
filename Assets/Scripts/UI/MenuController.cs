using DG.Tweening;

using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {
  [field: SerializeField, Header("UI")]
  public GameObject MenuRoot { get; private set; }

  [field: SerializeField, Header("Effects")]
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
    if (Input.GetKeyDown(KeyCode.Tab)) {
      ToggleMenu(!MenuRoot.activeSelf);
    }
  }

  public void ToggleMenu(bool toggleOn) {
    MenuRoot.SetActive(toggleOn);
    _cameraController.SetActive(!toggleOn);

    _inputController.cursorInputForLook = !toggleOn;
    _inputController.look = Vector2.zero;

    Cursor.lockState = toggleOn ? CursorLockMode.Confined : CursorLockMode.Locked;

    Time.timeScale = toggleOn ? 0f : 1f;
    _depthOfFieldEffect.enabled.value = toggleOn;

    DOTween
        .To(() =>
              _colorGradingEffect.saturation.value,
              x => _colorGradingEffect.saturation.value = x,
              toggleOn ? -100f : 0f,
              1f)
        .SetUpdate(true);
  }

  public void OnQuitButton() {
  #if UNITY_EDITOR
    // Application.Quit() does not work in the editor so
    // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
    UnityEditor.EditorApplication.isPlaying = false;
  #else
    Application.Quit();
  #endif
  }
}
