using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] int hitPoints = 3;

    GameObject parentGameObject;

    private void Start()
    {
        //parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
    }


    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        Debug.Log("Hit!");
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
    }
}
