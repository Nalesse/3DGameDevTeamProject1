using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [field: SerializeField] public int EnemiesAttacking { get; set; }

    private Enemy[] oldEnemies;

    public void GameOver()
    {
        Debug.Log("Game Over");
    }

    public void UpdateEnemyAttackCount()
    {
        Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();


        if (enemies == oldEnemies)
        {
            return;
        }

        foreach (var enemy in enemies)
        {
            if (enemy.CurrentState == Enemy.State.Attacking)
            {
                EnemiesAttacking += 1;
                EnemiesAttacking = Mathf.Clamp(EnemiesAttacking, 0, 2);
            }
        }

        oldEnemies = enemies;
    }



    private void Awake()
    {
        // Singleton setup lets the script be accessed form other scripts without using GameObject.Find
        if (Instance == null)
        {
            Instance = this;
        }

        EnemiesAttacking = 0;
    }
}
