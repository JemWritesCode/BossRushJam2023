using DG.Tweening;

using UnityEngine;
using UnityEngine.UI;

public class BossHudController : MonoBehaviour {
  [field: SerializeField]
  public Slider HealthBarSlider { get; private set; }

  [field: SerializeField]
  public TMPro.TMP_Text HealthBarText { get; private set; }

  void Awake() {
    Enemy.OnProcessHit += EnemyOnProcessHitHandler;
  }

  void OnDestroy() {
    Enemy.OnProcessHit -= EnemyOnProcessHitHandler;
  }

  void EnemyOnProcessHitHandler(object sender, EnemyProcessHitEventArgs args) {
    float hitPointsPercent = Mathf.Clamp01(args.HitPointsCurrent / args.HitPointsMax);

    HealthBarSlider.DOKill();
    HealthBarSlider.DOValue(hitPointsPercent, 0.25f).SetLink(gameObject);
    HealthBarText.DOText($"{hitPointsPercent:P0}", 0.25f).SetLink(gameObject);
  }
}