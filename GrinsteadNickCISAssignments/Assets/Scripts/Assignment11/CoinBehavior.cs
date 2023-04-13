using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    public IEnumerator Bounce()
    {
        while (true)
        {
            for (int i = 0; i < 10; ++i)
            {
                transform.Translate(0, 0.1f, 0);
                yield return new WaitForSeconds(0.1f);
            }

            for (int i = 0; i < 10; ++i)
            {
                transform.Translate(0, -0.1f, 0);
                yield return new WaitForSeconds(0.1f);
            }

            yield return null;
        }
    }
}
