using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [field: SerializeField] public int EnemiesAttacking { get; set; }


    public void GameOver()
    {
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
        EnemiesAttacking = Mathf.Clamp(EnemiesAttacking, 0, 2);
    }
}
