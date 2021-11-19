using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    #region Public Vars

    #endregion

    #region Privite Vars

    #endregion

    #region Serialized Fields

    [Header("AOE Settings")]

    [SerializeField] private Vector3 boxSize;

    [SerializeField] private Vector3 aoeOffset;

    #endregion


    public override void SingleTargetAttack(LayerMask target, int damage)
    {
        base.SingleTargetAttack(target, damage);

        if (Physics.Raycast(Ray, out HitData, 5, target))
        {
            Enemy enemy = HitData.transform.gameObject.GetComponent<Enemy>();
            enemy.DecreaseHealth(damage);
        }

    }

    public void AoeAttack()
    {

        Collider[] enemies = Physics.OverlapBox(transform.position + aoeOffset, boxSize / 2, transform.rotation, target);
        ///Physics.OverlapSphere(transform.position, aoeRadius, target);

        foreach (var enemy in enemies)
        {
            Enemy _enemy = enemy.GetComponent<Enemy>();
            _enemy.DecreaseHealth(5);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        ///Gizmos.DrawWireSphere(transform.position, aoeRadius);
        Gizmos.DrawWireCube(transform.position + aoeOffset, boxSize);
    }

    // Start is called before the first frame update
    private void Start()
    {
        healthBar.SetMaxHealthUI(health);
    }

    // Update is called once per frame
    private void Update()
    {
        PlayerMovement();
        PlayerInput();

        if (GetHealth() <= 0)
        {
            SetHealth(0);
            GameManager.Instance.GameOver();
        }
    }

    private void PlayerInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SingleTargetAttack(target, 5);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            AoeAttack();
        }
    }


    private void PlayerMovement()
    {
        var horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * movementSpeed * horizontalInput * Time.deltaTime);
    }
}
