/*
 * Nick Grinstead
 * PowerUpDecorator.cs
 * Assignment 4
 * This abstract class defines a decorator for a PlayerComponent object.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpDecorator : PlayerComponent
{
    public PlayerComponent wrappedPlayerObj;
}
