

using UnityEngine;

[CreateAssetMenu(fileName = "testScriptable", menuName = "ScriptableObjects/testVariables", order = 1)]
public class testScriptable : ScriptableObject
{
    [Header("TANK Settings")]
    public float tankSpeed = 0.2f;
    public float tankSize = 3f;




    [Space(20)]
    [Header("OTHERS")]
    public Sprite testSprite;
    public static Sprite square => tankMain.inst.variables.testSprite;
    public float arrowsDebugSize = 2;
    public float arrowsDebugA = 0.3f;



}