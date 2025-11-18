using System;
using NUnit.Framework;
using UnityEngine;


[CreateAssetMenu(fileName = "bulletData", order = 1, menuName = "ScriptableObjects/bulletData")]//
public class bulletData : ScriptableObject
{

    //! MAYBE THINGS INSIDE BULLET CONTRUCTOR .. NO CALLING THE SCRIPTABLE .. ..
    

    public Vector2 size;
    public float speed;
    public Color col;


    public void shoot(Vector2 offset, Vector2 dir)
    {

        //Debug.Log("SHOOT");

        Transform bull = new GameObject("bullet").transform;
        bull.localScale = size;
        var rb = bull.gameObject.AddComponent<Rigidbody2D>();

        bull.transform.position = offset;
        rb.linearVelocity = dir * speed;
        rb.gravityScale = 0;
        rb.linearDamping = 0;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        var spr = bull.gameObject.AddComponent<SpriteRenderer>();
        spr.sprite = testScriptable.square;
        spr.color = col;


        var collider = bull.gameObject.AddComponent<BoxCollider2D>();
        collider.isTrigger = true;
        var _bulletClass = new bullet();
        var collisionClass = new colliderClass(collider, _bulletClass, true);
        collisionManager.addCollider(collisionClass);

        _bulletClass._onDeath += () =>
        {
            collisionManager.returnCollider(collisionClass);
            if(bull != null && bull.gameObject != null) Destroy(bull.gameObject);
           

        };



        new Invo(() =>
        {

            _bulletClass?._onDeath.Invoke();
          
        }, 2);



    }



}

class bullet : ICollider
{
    public colliderClass.colliderType getMyType() => colliderClass.colliderType.bullet;



    public GameObject _obj;
    public Action _onDeath;


}
