using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PartyMember : MonoBehaviour
{
    IAbilityBehavior abilityBehavior;

    [SerializeField] int maxHealth;
    int currentHealth;

    [SerializeField] int abilityPower;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public string GetHealthTotals()
    {
        return currentHealth + " / " + maxHealth;
    }

    public void DoAbility()
    {
        if (abilityBehavior != null)
        {
            abilityBehavior.UseAbility(abilityPower);
        }
    }

    public void SetAbilityBehavior(IAbilityBehavior newAbility)
    {
        abilityBehavior = newAbility;
    }

    protected abstract void AnimateSprite();
} 
