using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 75;
    [SerializeField] float buildDelay = 1f;

    Bank bank;

    private void Start()
    {
        StartCoroutine(Build());            
    }

    public bool CreateTower(Tower tower, Vector3 position)
    {
        bank = FindObjectOfType<Bank>();

        if (bank == null) { Debug.Log("No bank"); return false; }

        if(bank.CurrentBalance >= cost)
        {
            Instantiate(tower.gameObject, position, Quaternion.identity);
            bank.Withdraw(cost);
            return true;
        }

        return false;
    }
       
    IEnumerator Build()
    {
        disableChildObjects();

        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(true);
            yield return new WaitForSeconds(buildDelay);

            // Check the nested GameObjects 
            foreach(Transform grandChild in child)
            {
                grandChild.gameObject.SetActive(true);
            }
        }
    }

    private void disableChildObjects()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);

            foreach (Transform grandChild in child)
            {
                grandChild.gameObject.SetActive(false);
            }
        }
    }
}
