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

    [SerializeField] private float aoeRadius;

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

        Collider[] enemies = Physics.OverlapSphere(transform.position, aoeRadius, target);

        foreach (var enemy in enemies)
        {
            Enemy _enemy = enemy.GetComponent<Enemy>();
            _enemy.DecreaseHealth(5);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, aoeRadius);
    }

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        PlayerMovement();

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
