
using Unity.VisualScripting;
using UnityEngine;



[CreateAssetMenu(fileName = "turretData", order = 1, menuName = "ScriptableObjects/turretData")]//
public class turretData : ScriptableObject
{



    [Header("TURRET")]

    public Vector2 turretSize;
    public Vector2 turretOffset;
    public Vector2 pivotOffset;
    public float rotateSpeed;

    public Color color;

    public turretClass makeTurret(Transform tank)
    {
        return new turretClass(this, tank);
    }

}

public class turretClass
{
    turretData _data;
    public Transform _rotationBase;
    public Transform shootPoint;

    public turretClass(turretData data, Transform tank)
    {
        _data = data;

        var pivot = new GameObject("pivot").transform;
        pivot.position = tank.position + (Vector3)_data.pivotOffset + Vector3.back;
        pivot.parent = tank;

        var turret = new GameObject("turret").transform;
        //turret.localScale = _data.turretSize;
        var spr = turret.AddComponent<SpriteRenderer>();
        //spr.drawMode = SpriteDrawMode.Sliced;
        //spr.size = _data.turretSize;
        spr.sprite = testScriptable.square;
        spr.color = _data.color;
        turret.transform.localScale = _data.turretSize;
        //turret.transform.localScale = Vector3.one;
        turret.position = pivot.position + (Vector3)_data.turretOffset;
        turret.parent = pivot;


        shootPoint = new GameObject("shootPoinst").transform;
        shootPoint.position = turret.position;
        shootPoint.parent = turret;


        _rotationBase = pivot;


    }

    public void updateMe(int rotate)
    {

        if (rotate != 0) _rotationBase.eulerAngles += Vector3.forward * _data.rotateSpeed * rotate;



    }


}

