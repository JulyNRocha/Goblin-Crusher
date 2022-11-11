using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI displayBalance;

    [SerializeField] int startBalance = 150;

    [SerializeField] int currentBalance;
    public int CurrentBalance { get { return currentBalance; } }

    void Awake()
    {
        currentBalance = startBalance;
        UpdateDisplay();
        
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        UpdateDisplay();
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        UpdateDisplay();

        if (currentBalance <= 0)
        {
            // Lose Game
            ReloadScene();
        }
    }

    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    void UpdateDisplay()
    {
        displayBalance.text = $"Gold: {currentBalance}";
    }

}
