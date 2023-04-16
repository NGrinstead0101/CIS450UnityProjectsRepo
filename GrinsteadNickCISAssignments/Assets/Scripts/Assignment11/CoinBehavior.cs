/*
* Nick Grinstead
* CoinBehavior
* Assignment 11
* This class handles how coins bounce up and down in the air.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    /// <summary>
    /// Coroutine that makes the object move up and down repeatedly
    /// </summary>
    /// <returns>An amount of time to wait</returns>
    public IEnumerator Bounce()
    {
        while (true)
        {
            for (int i = 0; i < 5; ++i)
            {
                transform.Translate(0, 0.1f, 0);
                yield return new WaitForSeconds(0.1f);
            }

            for (int i = 0; i < 5; ++i)
            {
                transform.Translate(0, -0.1f, 0);
                yield return new WaitForSeconds(0.1f);
            }

            yield return null;
        }
    }
}
