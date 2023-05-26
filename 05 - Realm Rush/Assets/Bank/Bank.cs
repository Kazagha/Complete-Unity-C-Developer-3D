using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance;

    GoldLabeler goldLabeler;

    public int CurrentBalance { get { return currentBalance; } }

    public void Start()
    {
        goldLabeler = FindObjectOfType<GoldLabeler>();
        if(goldLabeler == null) { Debug.Log("Can't find the label!"); }
        UpdateUI();
    }

    private void Awake()
    {
        currentBalance = startingBalance;
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        UpdateUI();
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

        UpdateUI();
    }

    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    void UpdateUI()
    {
        goldLabeler.DisplayGold(currentBalance);
    }
}
