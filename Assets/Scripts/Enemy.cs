using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Collider colissionMesh;

    [SerializeField] GameObject deathFX;
    [SerializeField] GameObject shotedFX;
    [SerializeField] int hitPoints = 10;

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
        GameObject sfx = Instantiate(shotedFX, transform.position, Quaternion.identity);
        hitPoints--;
    }

    private void KillEnemy()
    {
        GameObject dfx = Instantiate(deathFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
