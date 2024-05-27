using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isItemCollected = false;
    public bool isGateRepaired = false;
    public static GameManager Instance { get; private set; }
    public string currentObjective = "Find Energy Cell";

    private void Awake()
    {
        // Implement Singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void OnItemCollected()
    {
        isItemCollected = true;
        UIManager.Instance.AppendText("Current Objective: Repair Warp Gate");
    }

    public void IntroComplete()
    {
        UIManager.Instance.AppendText("Current Objective: Find Energy Cell");
        
    }

    public void UpdateObjective(string objective)
    {
        UIManager.Instance.AppendText("Current Objective: " + objective);
    }

    public void UpdateDistance(float distance)
    {
        if (isItemCollected)
            currentObjective = "Repair Warp Gate";
        UIManager.Instance.AppendText("Distance to Objective: " + distance.ToString("F2") + " units" + "\n" + "Current Objective: " + currentObjective);
    }

    public void OnPlayerEscaped()
    {
        if (isItemCollected && isGateRepaired)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("VictoryScreen");
        }
    }

    public void OnPlayerDeath()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("DefeatScreen");
    }
}
