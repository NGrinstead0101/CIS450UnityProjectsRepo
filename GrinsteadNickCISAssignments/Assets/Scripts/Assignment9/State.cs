using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface State
{
    public abstract void Steer(int direction);

    public abstract void Boost();

    public abstract void OnWait();

    public abstract void OnCollision();
}
