using System;

using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static event EventHandler<EnemyProcessHitEventArgs> OnProcessHit;

    [SerializeField] GameObject deathFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] int hitPoints = 3;

    GameObject parentGameObject;
    int hitPointsMax;

    private void Start()
    {
        //parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
        hitPointsMax = hitPoints;
    }


    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(fx, 2);
    }

    private void HitEnemy()
    {
        GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = gameObject.transform;
        Destroy(vfx, 3); // destroy the vfx so it doesn't clutter the hierarchy.
                         // I might need to change this to an object pool
    }


    private void ProcessHit()
    {
        if (hitPoints == 0)
        {
            KillEnemy();
        }
        else
        {
            HitEnemy();
            hitPoints--;
        }

        OnProcessHit?.Invoke(
            this, new() { EnemyHit = this, HitPointsCurrent = hitPoints, HitPointsMax = hitPointsMax });
    }
}

public class EnemyProcessHitEventArgs : EventArgs {
  public Enemy EnemyHit { get; set; }
  public float HitPointsCurrent { get; set; }
  public float HitPointsMax { get; set; }
}