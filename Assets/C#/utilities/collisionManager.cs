



using System.Collections.Generic;
using UnityEngine;



public class collisionManager : MonoBehaviour
{

    //!    if (!colliders[i]._col.bounds.Intersects(colliders[y]._col.bounds)) continue;  POSSIBLY NOT PERFECT BUT TEMP SOLUTION 

    static collisionManager instLocal;
    public static collisionManager inst
    {
        get
        {
            if (instLocal == null)
            {
                var g = new GameObject("colliderManager");
                instLocal = g.AddComponent<collisionManager>();
            }

            return instLocal;
        }
        set { instLocal = value; }

    }

    public void nothingButStart()
    {


    }
    public List<colliderClass> colliders = new();
    List<(ICollider a, ICollider b)> collisionsDetected;




    public (ICollider a, ICollider b)[] calculateCollisions()
    {

        collisionsDetected = new();

        for (int i = 0; i < colliders.Count; i++)
        {
            if (colliders[i]._detectOthers)
            {

                for (int y = 0; y < colliders.Count; y++)
                {
                    if (y == i) continue;
                    //if (!colliders[i]._col.IsTouching(colliders[y]._col)) 
                    if (!colliders[i]._col.bounds.Intersects(colliders[y]._col.bounds)) continue;

                    markCollision(colliders[i], colliders[y]);


                }



            }





        }

        return collisionsDetected.ToArray();


    }

    void markCollision(colliderClass a, colliderClass b)
    {
        collisionsDetected.Add(new(a._theClass, b._theClass));
    }


    //! MYBE OTHER SCRIPT SEPERATIONS OF THE BASE SYSTEM AND THE AFTER FUNCTIONALITY



    public static void addCollider(colliderClass col)
    {
        if (inst.colliders.Contains(col))
        {
            Debug.LogError("DOUBLE COLLIDER type == " + col.GetType());
            return;
        }
        inst.colliders.Add(col);

    }
    public static void returnCollider(colliderClass col)
    {
       
        inst.colliders.Remove(col);

    }



}
