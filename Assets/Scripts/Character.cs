using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    //This class holds shared attributes for the player and Enemy classes
    #region Public Vars
    public int health;
    public float movementSpeed;

    // Attack Vars
    public LayerMask target;
    public Ray ray;
    public RaycastHit hitData;

    #endregion

    /// <summary>
    /// Attacks the first target that the raycast hits. The target param specifies which layer mask to target
    /// </summary>
    /// <param name="layerMask"></param>
    public virtual void SingleTargetAttack(LayerMask target, int damage)
    {
        ray = new Ray(transform.position, transform.right);
        Debug.DrawRay(ray.origin, ray.direction * 3, Color.red);

        if(Physics.Raycast(ray, out hitData, 5, target))
        {
            Debug.Log(hitData.transform.gameObject.name + " took " + damage + " damage");
        }

        
    }

    #region Health Get / Set Methodes

    /// <summary>
    /// Decreases health by the amount that is passed in
    /// </summary>
    /// <param name="amount"></param>
    public void DecreaseHealth(int amount)
    {
        this.health -= amount;
    }

    /// <summary>
    /// Increases health by the amount that is passed in
    /// </summary>
    /// <param name="amount"></param>
    public void AddHealth(int amount)
    {
        this.health += amount;
    }

    /// <summary>
    /// Sets health to the amount that is passed in
    /// </summary>
    /// <param name="amount"></param>
    public void SetHealth(int amount)
    {
        this.health = amount;
    }

    /// <summary>
    /// Returns the curent amount of health
    /// </summary>
    public int GetHealth()
    {
        return this.health;
    }

    #endregion
}
