

using UnityEngine;

[CreateAssetMenu(fileName = "testScriptable", menuName = "ScriptableObjects/testVariables")]//, order = 1
public class testScriptable : ScriptableObject
{
    [Header("TANK Settings")]
    public float tankSpeed = 0.2f;
    public float tankSize = 3f;


    [Space(20)]
    [Header("BULLET SETTINGS")]
    public float bulletSpeed = 10f;
    public float bulletSize = 1f;

    [Space(20)]
    [Header("OTHERS")]
    public Sprite testSprite;



}