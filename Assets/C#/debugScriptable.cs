

using UnityEngine;

[CreateAssetMenu(fileName = "debugScriptable", menuName = "ScriptableObjects/debugScriptable", order = 1)]
public class debugScriptable : ScriptableObject
{
    [Header("DEBUG SETTINGS")]
    public float gazi;
    public int turn;
    public float lastGearChange;
    public int gear;
   


}