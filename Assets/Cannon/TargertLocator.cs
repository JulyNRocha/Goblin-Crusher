using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargertLocator : MonoBehaviour
{
    [SerializeField] Transform cannonHead;
    Transform target;
    
    void Start()
    {
        target = FindObjectOfType<EnemyMover>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        AimWeapon();
    }

    void AimWeapon()
    {
        cannonHead.LookAt(target);
    }

}
