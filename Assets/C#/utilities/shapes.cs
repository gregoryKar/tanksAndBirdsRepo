

using UnityEngine;

public class shapes
{

    public static SpriteRenderer makeSquare(Vector3 pos, Vector2 scale, string name, Color col)
    {
        var square = new GameObject(name);

        square.transform.position = pos;
        square.transform.localScale = Vector3.one * tankMain.inst.variables.arrowsDebugSize;

        var spr = square.AddComponent<SpriteRenderer>();
        spr.sprite = tankMain.inst.variables.testSprite;
        spr.color = col;

        return spr;

    }









}