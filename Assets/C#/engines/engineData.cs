using UnityEngine;


[CreateAssetMenu(fileName = "engineData", order = 1, menuName = "ScriptableObjects/engineTest")]//
public class engineData : ScriptableObject
{

    [Header("MOVEMENT")]
    public float linearDamping, angularDamping;
    public float mass;

    public float moveTorque, rotationTorque;
    public float whenTurnTorgueAdjust;

   
    public engineClass makeEngine(Transform tank)
    {

        engineClass newEngine = new engineClass(this, tank);
        return newEngine;
    }

}

