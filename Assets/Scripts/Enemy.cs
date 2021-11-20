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


    public override void SingleTargetAttack()
    {
        base.SingleTargetAttack();

        if (Physics.Raycast(Ray, out HitData, 5, target))
        {
            Player _player = HitData.transform.gameObject.GetComponent<Player>();
            _player.DecreaseHealth(damage);
        }
    }


    private void Awake()
    {
        player = GameObject.FindObjectOfType<Player>();
        healthBar = GetComponentInChildren<HealthBar>();
    }

    private void Start()
    {
        healthBar.SetMaxHealthUI(health);
    }

    // Update is called once per frame
    private void Update()
    {
        if (GetHealth() <= 0)
        {
            SetHealth(0);
            Destroy(this.gameObject);
        }
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
