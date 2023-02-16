/*
 * Nick Grinstead
 * ProjectileSpawner.cs
 * Assignment 5
 * This class takes player inputs to update their projectile selection and
 * calls a SimpleProjectileFactory to instantiate projectiles as necessary.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI selectionText;
    int projectileSelection = 0;

    SimpleProjectileFactory factory;

    /// <summary>
    /// Sets factory variable
    /// </summary>
    private void Awake()
    {
        factory = GetComponent<SimpleProjectileFactory>();
    }

    /// <summary>
    /// Calls the factory to instantiate the chosen projectile
    /// </summary>
    /// <param name="type">The projectile chosen</param>
    private void ShootProjectile(string type)
    {
        factory.SpawnProjectile(type);
    }

    /// <summary>
    /// Reads player inputs to update projectile selection and call ShootProjectile()
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            projectileSelection = 0;
            selectionText.text = "Current Projectile: Boulder";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            projectileSelection = 1;
            selectionText.text = "Current Projectile: Arrow";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            projectileSelection = 2;
            selectionText.text = "Current Projectile: Pebble";
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
        {
            switch (projectileSelection)
            {
                case 0:
                    ShootProjectile("Boulder");
                    break;

                case 1:
                    ShootProjectile("Arrow");
                    break;

                case 2:
                    ShootProjectile("Pebble");
                    break;
            }
        }
    }
}
