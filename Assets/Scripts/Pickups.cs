using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Pickups : MonoBehaviour
{
    #region Public Vars


    #endregion

    #region Private Vars

    private Player player;
    //private Rigidbody playerRb;

    private enum PickUpType

    {
        /// <summary>
        /// Gives the player health on pickup
        /// </summary>
        Health,

        /// <summary>
        /// Temporarily increases the players damage on pickup 
        /// </summary>
        Damage
    }
    #endregion

    #region Serialized Fields

    [SerializeField] private PickUpType currentType;

    [Header("Health Pickup Settings")]
    [SerializeField] private int healthToAdd;

    [Header("Damage Pickup Settings")]
    [SerializeField] private int damageBoostAmount;
    [SerializeField] private int boostDuration;

    #endregion

    //bool hasDamageBoost;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindObjectOfType<Player>();
        //playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(hasDamageBoost && Input.GetMouseButtonDown(0))
        //{
        //        SingleTargetAttack(target, 10);
        //}
       
    }

    //private void OntiggerEnter(Collider other)
    //{
    //    //utilizes the tag system in unity to check whether the player pickup a damage boost or a health pickup
    //    //then deletes the game object once it is picked up

    //    if(other.CompareTag("DamageBoost"))
    //    {
    //        Debug.Log("your damage has increased");
    //        hasDamageBoost = true;
    //        Destroy(other.gameObject);
    //        StartCoroutine(DamageBoost());
    //    }
    //    else if (other.CompareTag("Health"))
    //    {
    //        Debug.Log("You picked up health");
    //        AddHealth(10);
    //        Destroy(other.gameObject);
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        
        if (currentType == PickUpType.Health)
        {
            player.AddHealth(healthToAdd);
            Destroy(gameObject);
        }
        else if (currentType == PickUpType.Damage)
        {
            StartCoroutine(DamageBoost());

            // Coroutine stops if the object gets destroyed so I have to do a fake destroy.
            GetComponentInChildren<MeshRenderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
        }
    }

    private IEnumerator DamageBoost()
    {
        var oldDamage = player.GetDamage();
        player.SetDamage(damageBoostAmount);
        yield return new WaitForSeconds(boostDuration);
        player.SetDamage(oldDamage);
        Destroy(gameObject);
    }
}
