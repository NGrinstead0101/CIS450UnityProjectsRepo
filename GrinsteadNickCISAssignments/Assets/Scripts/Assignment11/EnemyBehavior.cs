using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public IEnumerator Patrol()
    {
        while (true)
        {
            for (int i = 0; i < 5; ++i)
            {
                transform.Translate(1, 0, 0);
                yield return new WaitForSeconds(0.5f);
            }

            for (int i = 0; i < 5; ++i)
            {
                transform.Translate(-1, 0, 0);
                yield return new WaitForSeconds(0.5f);
            }

            yield return null;
        }
    }
}
