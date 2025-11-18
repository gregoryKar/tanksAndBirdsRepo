

using UnityEngine;


public class tankMain : MonoBehaviour
{

    public static tankMain inst;

    private void Awake()
    {
        inst = this;
    }

    [SerializeField] engineData _engineData;
    [SerializeField] turretData _turretData;
    [SerializeField] bulletData _bullets;
    public testScriptable variables;
    [SerializeField] debugScriptable myDebug;

    engineClass myEngine;
    orestisHelper helper;
    turretClass turret;


    collisionHandler _collisionHandler;
    collisionManager _collisionManager;

    void Start()
    {
        _collisionManager = collisionManager.inst;
        _collisionHandler = new();
        _collisionHandler.InitializeRules();

        wall.spawnWall(new Vector2(3, 3));


        helper = new orestisHelper();

        var tank = new GameObject("tank");
        var spr = tank.AddComponent<SpriteRenderer>();
        spr.sprite = variables.testSprite;
        spr.size = new Vector2(1, 2) * variables.tankSize;
        spr.drawMode = SpriteDrawMode.Sliced;
        tank.transform.localScale = Vector3.one;
        //tank.transform.localScale = new Vector3(1, 1, 1) * variables.tankSize;


        myEngine = _engineData.makeEngine(tank.transform);

        turret = _turretData.makeTurret(tank.transform);


    }




    void Update()
    {
        helper.updateArrows(Input.GetKey(KeyCode.W), Input.GetKey(KeyCode.S), Input.GetKey(KeyCode.D), Input.GetKey(KeyCode.A));

        int turn = 0;
        if (Input.GetKey(KeyCode.A)) turn = -1;
        else if (Input.GetKey(KeyCode.D)) turn = 1;

        int gazi = 0;
        if (Input.GetKey(KeyCode.W)) gazi = 1;
        else if (Input.GetKey(KeyCode.S)) gazi = -1;


        myEngine.updateMe(turn, gazi);



        int turnTurret = 0;
        if (Input.GetKey(KeyCode.RightArrow)) turnTurret = -1;
        if (Input.GetKey(KeyCode.LeftArrow)) turnTurret = 1;

        turret.updateMe(turnTurret);

        if (Input.GetKeyDown(KeyCode.Space)) _bullets.shoot(turret.shootPoint.position + turret.shootPoint.up, turret._rotationBase.up);


        var collisions = _collisionManager.calculateCollisions();
        if (collisions.Length > 0) Debug.LogError("COLLISION HAPPENED");
        _collisionHandler.HandleCollision(collisions);

        

    }






}