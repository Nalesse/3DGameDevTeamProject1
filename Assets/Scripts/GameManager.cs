using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    // Global Data Management
    [field: SerializeField] public int EnemiesAttacking { get; set; }


    public void GameOver()
    {
        // TODO finish game over function and Implement UI
        Debug.Log("Game Over");
    }

    private void Awake()
    {
        // Singleton setup lets the script be accessed form other scripts without using GameObject.Find
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Update()
    {
        // Limits the number of enemies attacking to 2 
        EnemiesAttacking = Mathf.Clamp(EnemiesAttacking, 0, 2);
    }
}
