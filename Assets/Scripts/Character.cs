using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    // This class holds shared attributes for the player and Enemy classes
    #region Public/ Protected Vars
    [SerializeField] protected int health;
    [SerializeField] protected int damage;
    [SerializeField] protected HealthBar healthBar;
    [SerializeField] protected float movementSpeed;

    // Attack Vars
    [SerializeField] protected LayerMask target;
    protected Ray Ray;
    protected RaycastHit HitData;

    #endregion

    /// <summary>
    /// Attacks the first target that the raycast hits. The target param specifies which layer mask to target
    /// </summary>
    public virtual void SingleTargetAttack()
    {
        Ray = new Ray(transform.position, transform.right);
        Debug.DrawRay(Ray.origin, Ray.direction * 2, Color.red);

        if (Physics.Raycast(Ray, out HitData, 2, target))
        {
            Debug.Log(HitData.transform.gameObject.name + " took " + damage + " damage");
        }
    }

    #region Health Get / Set Methodes

    /// <summary>
    /// Decreases health by the amount that is passed in
    /// </summary>
    /// <param name="amount">How much health to subtract</param>
    public void DecreaseHealth(int amount)
    {
        healthBar.gameObject.SetActive(true);
        if(healthBar.enabled == true)
        {
            health -= amount;
            healthBar.SetHealthUI(health);
        }
        
    }

    /// <summary>
    /// Increases health by the amount that is passed in
    /// </summary>
    /// <param name="amount"> How much health to add</param>
    public void AddHealth(int amount)
    {
        health += amount;
        healthBar.SetHealthUI(health);
    }

    /// <summary>
    /// Sets health to the amount that is passed in
    /// </summary>
    /// <param name="amount"> What value to set the health to</param>
    public void SetHealth(int amount)
    {
        health = amount;
        healthBar.SetHealthUI(health);
    }

    /// <summary>
    /// Returns the current amount of health
    /// </summary>
    /// <returns>
    /// The current amount of health <see cref="int"/>.
    /// </returns>
    public int GetHealth()
    {
        return health;
    }

    #endregion

    #region Damage Get/ Set Methodes

    /// <summary>
    /// Sets the amount of damage the entity will do
    /// </summary>
    /// <param name="amount">
    /// the value to set the damage to
    /// </param>
    public void SetDamage(int amount)
    {
        damage = amount;
    }

    public int GetDamage()
    {
        return damage;
    }

    #endregion
}
