
using System;
using System.Collections.Generic;
using UnityEngine;
public class invoManager : MonoBehaviour
{

    static invoManager instLocal;
    public static invoManager inst()
    {

        if (instLocal == null)
        {
            var gameObject = new GameObject("invoManager");
            instLocal = gameObject.AddComponent<invoManager>();
        }

        return instLocal;

    }


    List<Invo> invokes = new();


    void Update()
    {
        for (int i = invokes.Count - 1; i >= 0; i--)
        {

            if (invokes[i]._when <= Time.time)
            {
                //Debug.Log("INVOKED");
                invokes[i]._action.Invoke();
                invokes.RemoveAt(i);
                if (invokes.Count == 0) break;
            }

        }
    }

    public void addInvoke(Invo thisOne)
    {
        invokes.Add(thisOne);
    }


}

public class Invo
{


    public Invo(Action action, double after)
    {
        _when = Time.time + after;
        _action = action;
        invoManager.inst().addInvoke(this);
    }

    public Action _action;
    public double _when;



}