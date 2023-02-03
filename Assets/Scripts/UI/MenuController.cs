using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class MenuController : MonoBehaviour {
  [field: SerializeField]
  public GameObject MenuRoot { get; private set; }

  [field: SerializeField]
  public PostProcessVolume MenuCameraEffect { get; private set; }

  GameObject _cameraController;

  void Awake() {
    _cameraController = GameObject.FindGameObjectWithTag("CameraController");

    ToggleMenu(toggleOn: false);
  }

  void Update() {
    if (Input.GetKeyDown(KeyCode.Escape)) {
      ToggleMenu(!MenuRoot.activeSelf);
    }
  }

  public void ToggleMenu(bool toggleOn) {
    MenuRoot.SetActive(toggleOn);
    MenuCameraEffect.enabled = toggleOn;
    _cameraController.SetActive(!toggleOn);

    Cursor.lockState = toggleOn ? CursorLockMode.None : CursorLockMode.Locked;
    Time.timeScale = toggleOn ? 0f : 1f;
  }
}
