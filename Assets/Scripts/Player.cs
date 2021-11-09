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

    #endregion


    public override void SingleTargetAttack(LayerMask target, int damage)
    {
        base.SingleTargetAttack(target, damage);

        if (Physics.Raycast(ray, out hitData, 5, target))
        {
            Enemy enemy = hitData.transform.gameObject.GetComponent<Enemy>();
            enemy.DecreaseHealth(damage);
        }

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
    }


    private void PlayerMovement()
    {
        var horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * movementSpeed * horizontalInput * Time.deltaTime);
    }
}
