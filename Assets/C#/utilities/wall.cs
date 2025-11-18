
using System;
using UnityEngine;

public class wall : MonoBehaviour, ICollider
{


    //! MAYBE SOME ENTITY SYSTEM WALL IS JUST SOMETHING WITH this and this in the collider and in the onDeath onDamage etc .. .. 



    public static void spawnWall(Vector2 pos)
    {

        var spr = shapes.makeSquare(pos, Vector2.one, "wall", Color.gray);
        var obj = spr.gameObject;
        var col = obj.AddComponent<BoxCollider2D>();
        var wall = obj.AddComponent<wall>();

        var collisionClass = new colliderClass(col, wall, false);
        collisionManager.addCollider(collisionClass);
        wall.onDeath += () =>
        {
            collisionManager.returnCollider(collisionClass);
            Destroy(obj);
        };
    }

    int damageTaken;
    public void addDamage()
    {

        Debug.LogError("WALL DMAGED");  

        damageTaken++;
        if (damageTaken > 3) onDeath?.Invoke();


    }

    Action onDeath;

    public colliderClass.colliderType getMyType() => colliderClass.colliderType.wall;

}