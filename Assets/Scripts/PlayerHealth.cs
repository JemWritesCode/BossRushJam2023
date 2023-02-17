using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float playerHealthPoints = 50;

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("A particle collided with the player.");
        playerHealthPoints--;
    }
}
