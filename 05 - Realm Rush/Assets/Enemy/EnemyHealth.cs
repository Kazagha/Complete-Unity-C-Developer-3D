using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;

    int currentHitPoints = 0;
    
    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        currentHitPoints -= 1;

        if (currentHitPoints <= 0)
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}
