using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance;

    public int CurrentBalance { get { return currentBalance; } }

    public void Deposit(int amount)
    {        
        currentBalance += Mathf.Abs(amount);
    }

    private void Awake()
    {
        currentBalance = startingBalance;
    }

    public void Withdraw(int amount)
    {
        // Absolute Value of amount 
        int abs_amount = Mathf.Abs(amount);

        // Confirm the amount is available 
        //if (abs_amount <= currentBalance)
        //{
        currentBalance -= Mathf.Abs(amount);
        //}

        if(currentBalance < 0)
        {
            ReloadScene();
        }
    }

    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
