using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    #region Public Vars

    #endregion

    #region Privite Vars

    private Player player;
    #endregion

    #region Serialized Fields

    #endregion

    private void Awake()
    {
        player = GameObject.FindObjectOfType<Player>();
    }

    // Update is called once per frame
    private void Update()
    {
        MoveToPlayer();
    }

    private void MoveToPlayer()
    {
        var stoppingDistance = 1.5;

        if (Vector3.Distance(transform.position, player.transform.position) >= stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, movementSpeed * Time.deltaTime);
        }
        
    }
}
