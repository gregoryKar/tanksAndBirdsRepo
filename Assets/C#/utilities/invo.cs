using System;
using UnityEngine;



//! INVO IN TANKS 
public class invo // : IComparable<invo>, IEquatable<invo>
{

    public Action _action;
    public float _end;
    public int _repeatsLeft;
    public float _delay;

    private invo(Action action, float delay, int repeatsLeft)
    {
        _action = action;
        _end = myTime.now;
        _repeatsLeft = repeatsLeft;

        //invoManager.inst.addInvo(this, gameOn);
    }

    public static void create(Action action, float delay) => new invo(action, delay, 0);
    public static void repeat(Action action, float delay, int repeat) => new invo(action, delay, repeat);









    // public int CompareTo(invo other)
    // {
    //     return _endTime.CompareTo(other._endTime);
    // }

    // public bool Equals(invo other)
    // {
    //     return this == other;
    // }





}