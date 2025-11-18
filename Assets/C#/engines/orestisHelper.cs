

using UnityEngine;

public class orestisHelper
{

    SpriteRenderer[] arrows;

    SpriteRenderer makeSquare(Vector3 pos, Vector2 scale, string name, Color col)
    {
        var square = new GameObject(name);

        square.transform.position = pos;
        square.transform.localScale = Vector3.one * tankMain.inst.variables.arrowsDebugSize;

        var spr = square.AddComponent<SpriteRenderer>();
        spr.sprite = tankMain.inst.variables.testSprite;
        spr.color = col;

        return spr;

    }

    public orestisHelper()
    {
        arrows = new SpriteRenderer[4];

        Vector2 scale = Vector2.one * tankMain.inst.variables.arrowsDebugSize;
        Color col = Color.red;
        col.a =   tankMain.inst.variables.arrowsDebugA;

        arrows[0] = makeSquare(new Vector3(0, 1, 0), scale, "up ", col);
        arrows[1] = makeSquare(new Vector3(0, -1, 0), scale, "down ", col);
        arrows[2] = makeSquare(new Vector3(1, 0, 0), scale, "right ", col);
        arrows[3] = makeSquare(new Vector3(-1, 0, 0), scale, "left ", col);


    }


    public void updateArrows(bool up, bool down, bool right, bool left)
    {

        arrows[0].enabled = up;
        arrows[1].enabled = down;
        arrows[2].enabled = right;
        arrows[3].enabled = left;

    }


}