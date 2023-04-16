/*
* Nick Grinstead
* EnemyBehavior
* Assignment 11
* This class handles how enemies patrol back and forth.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    /// <summary>
    /// Coroutine that makes the object move right and left repeatedly
    /// </summary>
    /// <returns>An amount of time to wait</returns>
    public IEnumerator Patrol()
    {
        while (true)
        {
            for (int i = 0; i < 10; ++i)
            {
                transform.Translate(0.4f, 0, 0);
                yield return new WaitForSeconds(0.15f);
            }

            for (int i = 0; i < 10; ++i)
            {
                transform.Translate(-0.4f, 0, 0);
                yield return new WaitForSeconds(0.15f);
            }

            yield return null;
        }
    }
}
