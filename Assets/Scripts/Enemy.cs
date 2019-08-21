using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Collider colissionMesh;

    [SerializeField] ParticleSystem deathFX;
    [SerializeField] ParticleSystem shotedFX;
    [SerializeField] int hitPoints = 6;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if(hitPoints < 1)
        {
            KillEnemy();
        }
    }

    private void ProcessHit()
    {
        shotedFX.Play();
        hitPoints--;
    }

    private void KillEnemy()
    {
        var dfx = Instantiate(deathFX, transform.position, Quaternion.identity);
        dfx.Play();
        Destroy(gameObject);
    }
}
