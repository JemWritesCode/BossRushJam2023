using DG.Tweening;

using UnityEngine;
using UnityEngine.UI;

public class PlayerHudController : MonoBehaviour {
  [field: SerializeField]
  public Slider HealthBarSlider { get; private set; }

  void Awake() {
    PlayerHealth.OnPlayerHit += OnPlayerHitHandler;
  }

  void OnDestroy() {
    PlayerHealth.OnPlayerHit -= OnPlayerHitHandler;
  }

  void OnPlayerHitHandler(object sender, PlayerHitEventArgs args) {
    float hitPointsPercent = Mathf.Clamp01(args.HealthPointsCurrent / args.HealthPointsMax);

    HealthBarSlider.DOKill();
    HealthBarSlider.DOValue(hitPointsPercent, 0.25f).SetLink(gameObject);
  }
}
