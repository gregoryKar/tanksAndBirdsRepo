
using Unity.VisualScripting;
using UnityEngine;


public class engineClass
{
    engineData _data;
    Transform _tank;
    Rigidbody2D _rb;



    public engineClass(engineData data, Transform tank)
    {
        _data = data;
        _tank = tank;

        _rb = tank.AddComponent<Rigidbody2D>();
        _rb.gravityScale = 0;
        _rb.linearDamping = _data.linearDamping;
        _rb.angularDamping = _data.angularDamping;
        _rb.mass = _data.mass;
    }
    public void updateMe(int turn, int move)
    {

        _rb.linearDamping = _data.linearDamping;//! EDIT
        _rb.angularDamping = _data.angularDamping;
        _rb.mass = _data.mass;



        if (turn != 0) _rb.AddTorque(turn * -1 * _data.rotationTorque * Time.deltaTime);

        float turnAdjust = (turn != 0) ? _data.whenTurnTorgueAdjust : 1;
        if (move != 0) _rb.AddForce(_tank.up * move * _data.moveTorque * turnAdjust * Time.deltaTime);




    }



}
