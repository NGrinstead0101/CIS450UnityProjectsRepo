using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandSetter : MonoBehaviour
{
    [SerializeField] PlayerInputsInvoker invoker;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Receiver"))
        {
            invoker.SetCommands(collision.gameObject.GetComponent<Receiver>());
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Receiver"))
        {
            invoker.SetCommands(null);
        }
    }

    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Receiver"))
    //    {
    //        invoker.SetCommands(collision.gameObject.GetComponent<Receiver>());
    //    }
    //}
}
