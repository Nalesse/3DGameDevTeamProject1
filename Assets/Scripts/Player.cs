using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    #region Public Vars

    public static Player Instance { get; private set; }

    #endregion

    #region Privite Vars

    private int maxHealth;

    private Vector3 playerRotation;

    #endregion

    #region Serialized Fields
    [Header("Player Movement")]
    [SerializeField] private float maxZ;
    [SerializeField] private float minZ;

    [Header("AOE Settings")]

    [SerializeField] private Vector3 boxSize;

    [SerializeField] private Vector3 aoeOffset;

    #endregion

    #region Attacks

    public override void SingleTargetAttack()
    {
        base.SingleTargetAttack();

        if (Physics.Raycast(Ray, out HitData, 2, target))
        {
            Enemy enemy = HitData.transform.gameObject.GetComponent<Enemy>();
            enemy.DecreaseHealth(damage);
        }

    }

    public void AoeAttack()
    {

        Collider[] enemies = Physics.OverlapBox(transform.position + aoeOffset, boxSize / 2, transform.rotation, target);

        // Rotates the overlap if the player changes direction
        if (Math.Abs(playerRotation.y - 180) < 0.1)
        {
            enemies = Physics.OverlapBox(transform.position - aoeOffset, boxSize / 2, transform.rotation, target);
        }


        foreach (var enemy in enemies)
        {
            Enemy _enemy = enemy.gameObject.GetComponent<Enemy>();

            if (_enemy != null)
            {
                _enemy.DecreaseHealth(damage);
            }
            
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        // Rotates the debug box with the player
        if (Math.Abs(playerRotation.y - 180) < 0.1)
        {
            Gizmos.DrawWireCube(transform.position - aoeOffset, boxSize);
        }
        else
        {
            Gizmos.DrawWireCube(transform.position + aoeOffset, boxSize);
        }
    }

    #endregion

    private void Awake()
    {
        // Singleton setup lets the script be accessed form other scripts without using GameObject.Find
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        maxHealth = health;
        healthBar.SetMaxHealthUI(maxHealth);
    }

    // Update is called once per frame
    private void Update()
    {
        PlayerMovement();
        PlayerInput();
        SetHealth(Mathf.Clamp(health, 0, maxHealth));
    }

    private void PlayerInput()
    {
        // Input for player attacks
        if (Input.GetMouseButtonDown(0))
        {
            SingleTargetAttack();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            AoeAttack();
        }
    }


    private void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        playerRotation = transform.eulerAngles;
        Vector3 referenceDirection = Vector3.right;

        if (horizontalInput > 0)
        {
            playerRotation.y = 0;
            transform.rotation = Quaternion.Euler(playerRotation);
            referenceDirection = Vector3.right;
        }
        else if (horizontalInput < 0)
        {
            playerRotation.y = 180;
            transform.rotation = Quaternion.Euler(playerRotation);
            referenceDirection = Vector3.left;
        }

        // Moves player left or right based on horizontal input
        transform.Translate(referenceDirection * movementSpeed * horizontalInput * Time.deltaTime);


    }
}
