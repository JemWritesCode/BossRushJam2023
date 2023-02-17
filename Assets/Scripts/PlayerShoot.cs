using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] ParticleSystem blasterParticles;

    private void Update()
    {
        ProcessFiring();
    }

    void ProcessFiring()
    {
        if (Input.GetButton("Fire1"))
        {
            SetBlasterActive(true);
        }
        else
        {
            SetBlasterActive(false);
        }
    }

    void SetBlasterActive(bool isActive)
    {
        var emissionModule = blasterParticles.emission;
            emissionModule.enabled = isActive;
    }
}
