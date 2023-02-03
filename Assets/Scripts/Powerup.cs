using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public ParticleSystem pickupEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }

    private void Pickup(Collider player)
    {
        //Instantiate(pickupEffect, transform.position, transform.rotation);

        pickupEffect.Play();

        // player effect

        Destroy(gameObject);
    }
}
