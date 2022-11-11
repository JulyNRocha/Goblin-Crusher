using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargertLocator : MonoBehaviour
{
    [SerializeField] Transform cannonHead;
    [SerializeField] ParticleSystem cannonParticles;
    [SerializeField] float atackRange;
    Transform target;

    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    void FindClosestTarget()
    {
        Enemy[] enemys = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach(Enemy enemy in enemys)
        {
            float targetDistance = Vector3.Distance(this.transform.position, enemy.transform.position);

            if(targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }

        target = closestTarget;
    }

    void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);
        cannonHead.LookAt(target);

        if(targetDistance < atackRange)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
    }

    void Attack(bool IsActive)
    {
        var emissionModule = cannonParticles.GetComponent<ParticleSystem>().emission;
        emissionModule.enabled = IsActive;
    }
}
