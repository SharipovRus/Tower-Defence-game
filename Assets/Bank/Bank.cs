using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currnetBalance;
    public int CurrentBalance { get { return currnetBalance; }}



    [SerializeField] TextMeshProUGUI displayBalance;

    void Awake() 
    {
        currnetBalance = startingBalance;
        UpdateDisplay();
    }

    public void Deposit(int amount)
    {
        currnetBalance += Mathf.Abs(amount);
        UpdateDisplay();
    }

    public void Withdraw(int amount)
    {
        currnetBalance -= Mathf.Abs(amount);
        UpdateDisplay();

        if(currnetBalance < 0)
        {
            ReloadScene();
        }
    }

    void UpdateDisplay()
    {
        displayBalance.text = "Gold: " + currnetBalance;
    }


    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

}
