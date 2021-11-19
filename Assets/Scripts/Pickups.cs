using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Pickups : Character
{
    #region Public Vars


    #endregion

    #region Private Vars

    private Player player;
    private Rigidbody playerRb;
    #endregion

    #region Serialized Fields


    #endregion

    #region Health Get/Set
        

    #endregion

    bool hasDamageBoost;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindObjectOfType<Player>();
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hasDamageBoost && Input.GetMouseButtonDown(0))
        {
                SingleTargetAttack(target, 10);
        }
       
    }

    private void OntiggerEnter(Collider other)
    {
        //utilizes the tag system in unity to check whether the player pickup a damage boost or a health pickup
        //then deletes the game object once it is picked up

        if(other.CompareTag("DamageBoost"))
        {
            Debug.Log("your damage has increased");
            hasDamageBoost = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
        else if (other.CompareTag("Health"))
        {
            Debug.Log("You picked up health");
            AddHealth(10);
            Destroy(other.gameObject);
        }
    }

    // creates a sort of repeatable function that will activate when called
    // once activated the function will start a ten second timer which is
    // going to determine the duration of the damage boost
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(10);
        hasDamageBoost = false;
    }


    
}
