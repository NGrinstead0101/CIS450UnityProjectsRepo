using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Receiver : MonoBehaviour
{
    protected Vector2 initialPos;
    [SerializeField] protected float maxDistance;
    [SerializeField] protected float speed;

    private void Awake()
    {
        initialPos = transform.position;
    }

    public abstract void Move(int direction);

    public Vector2 GetPosition()
    {
        return gameObject.transform.position;
    }

    public void SetPosition(Vector2 position)
    {
        transform.position = position;
    }

    public void StopMovement()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}

