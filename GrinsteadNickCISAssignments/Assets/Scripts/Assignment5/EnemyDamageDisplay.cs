/*
 * Nick Grinstead
 * EnemyDamageDisplay.cs
 * Assignment 5
 * This class displays the damage that the target dummies have taken.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyDamageDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI damageDisplay;
    int damageTaken = 0;

    /// <summary>
    /// Sets initial damageDisplay text
    /// </summary>
    private void Awake()
    {
        damageDisplay.text = "Damage: " + damageTaken;
    }

    /// <summary>
    /// Called by a projectile when it hits this object to increment damageTaken
    /// </summary>
    /// <param name="damage">The amount of damage taken</param>
    public void TakeDamage(int damage)
    {
        damageTaken += damage;
        damageDisplay.text = "Damage: " + damageTaken;
    }
}
