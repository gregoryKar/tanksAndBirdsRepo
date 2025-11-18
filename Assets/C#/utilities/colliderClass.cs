

using System;
using UnityEngine;


[Serializable]
public class colliderClass
{


    // public bitmap {
    // tank , bullet    
    // }

    public ICollider _theClass;
    public bool _detectOthers;
    public Collider2D _col;

    public colliderClass(Collider2D col, ICollider theClass, bool detectOthers)
    {
        _theClass = theClass;
        _col = col;
        _detectOthers = detectOthers;

    }

    public enum colliderType
    {
        wall, tank, bullet
    }


}

public interface ICollider
{



    public colliderClass.colliderType getMyType();

}
