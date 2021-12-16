using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Gets the Current Instance for the GameManager, used for singleton
    /// </summary>
    public static GameManager Instance { get; private set; }

    /// <summary>
    /// Gets or sets the number of enemies currently attacking the player 
    /// </summary>
    [field: SerializeField] public int EnemiesAttacking { get; set; }

    [SerializeField] private GameObject gameOverUI;


    public void GameOver()
    {
        gameOverUI.SetActive(true);
    }

    private void Awake()
    {
        // Singleton setup lets the script be accessed form other scripts without using GameObject.Find
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        gameOverUI.SetActive(false);
    }

    private void Update()
    {
        // Limits the number of enemies attacking to 2 
        EnemiesAttacking = Mathf.Clamp(EnemiesAttacking, 0, 2);
    }
}
