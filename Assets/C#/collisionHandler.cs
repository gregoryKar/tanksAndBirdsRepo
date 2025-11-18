using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class collisionHandler
{




    Dictionary<(colliderClass.colliderType, colliderClass.colliderType), Action<ICollider, ICollider>> rules = new();
    public void InitializeRules()
    {
        rules = new Dictionary<(colliderClass.colliderType, colliderClass.colliderType), Action<ICollider, ICollider>>();

        // Register rules
        Register(colliderClass.colliderType.bullet, colliderClass.colliderType.wall, (a, b) =>
        {
            if (a is bullet _bull) _bull._onDeath();
            if (b is wall _wall) _wall.addDamage();
        });//((Player)a).TakeDamage(10)

    }

    public void Register(colliderClass.colliderType a, colliderClass.colliderType b, Action<ICollider, ICollider> handler)
    {
        rules[(a, b)] = handler;
    }


    public void HandleCollision((ICollider a, ICollider b)[] array)
    {

        for (int i = 0; i < array.Length; i++)
        {
            HandleCollision(array[i].a, array[i].b);
        }

    }

    public void HandleCollision(ICollider a, ICollider b)
    {
        if (rules.TryGetValue((a.getMyType(), b.getMyType()), out var handler))
            handler?.Invoke(a, b);
        else if (rules.TryGetValue((b.getMyType(), a.getMyType()), out var handlerReverse))
            handlerReverse?.Invoke(b, a);
        else
            Debug.Log($"No rule for {a.getMyType()} <-> {b.getMyType()}");
    }
}


