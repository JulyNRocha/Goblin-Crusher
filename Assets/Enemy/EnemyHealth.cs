using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;

    [Tooltip("Add amout to maxHitPoint when enemy dies")]
    [SerializeField] int difficultyRamp = 1;

    [SerializeField] GameObject impactVFX;

    int currentHitPoints = 0;
    GameObject parentGameObject;

    Enemy enemy;
    
    void OnEnable()
    {
        parentGameObject = GameObject.FindWithTag("SpawnAtRunTime");
        currentHitPoints = maxHitPoints;
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void OnParticleCollision(GameObject other)
    {
       ProcessHit(); 
    }

    void ProcessHit()
    {
        GameObject vfx = Instantiate(impactVFX , transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform; 
        
        currentHitPoints--;

        if (currentHitPoints <= 0)
        {
            gameObject.SetActive(false);
            maxHitPoints += difficultyRamp;
            enemy.RewardGold();
        }
    }

}
