using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem projectileParticles;
    [SerializeField] float range = 15f;

    Transform target;

    // Update is called once per frame
    void Update()
    {
        FindClosestEnemy();
        aimWeapon();
    }

    private void FindClosestEnemy()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach(Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if(targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }

        target = closestTarget;
    }

    void aimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.transform.position);
        // Check target is within range 
        if (targetDistance < range)
        {
            weapon.transform.LookAt(target);
            Attack(true);
        }
        else
        {
            Attack(false);
        }
    }

    void Attack(bool isActive)
    {
        // Local Variable for the Emission system (can't be accessed without first caching it) 
        var emission = projectileParticles.emission;
        // Set the emission to enabled/disabled
        emission.enabled = isActive;
    }
}
