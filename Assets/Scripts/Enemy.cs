using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] int hits = 20;

    // Start is called before the first frame update
    void Start()
    {
        AddBoxCollider();
    }

    private void AddBoxCollider()
    {
        Collider enemyBoxCollider = gameObject.AddComponent<BoxCollider>();
        enemyBoxCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if(hits <= 1)
        {
            KillEnemy();
        }
    }

    private void ProcessHit()
    {
        hits--;
    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        print("enemy killed");
        Destroy(gameObject);
    }
}
