using System;

using UnityEngine;

public class PlayerHealth : MonoBehaviour {
  public static event EventHandler<PlayerHitEventArgs> OnPlayerHit;

  [field: SerializeField]
  public float PlayerHealthPoints { get; private set; } = 50;

  float _playerHealthPointsMax = 50f;

  void Start() {
    _playerHealthPointsMax = PlayerHealthPoints;
  }

  void OnParticleCollision(GameObject other) {
    Debug.Log("A particle collided with the player.");
    PlayerHealthPoints--;

    OnPlayerHit?.Invoke(
        this, new() { HealthPointsMax = _playerHealthPointsMax, HealthPointsCurrent = PlayerHealthPoints });

    if(PlayerHealthPoints == 0) { KillPlayer(); }
  }

    private void KillPlayer()
    {
        
    }
}

public class PlayerHitEventArgs : EventArgs {
  public float HealthPointsMax { get; set; }
  public float HealthPointsCurrent { get; set; }
}