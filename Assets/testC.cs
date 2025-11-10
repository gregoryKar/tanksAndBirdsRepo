using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class testC : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] testScriptable variables;

    void Start()
    {
        tank = new GameObject().transform;
        tank.AddComponent<SpriteRenderer>().sprite = variables.testSprite;
    }

    Transform tank;

    List<GameObject> bullets = new();
    void testFallingBullets()
    {
        for (int i = bullets.Count - 1; i >= 0; i--)
        {
            if (bullets.Count < 1) break;
            if (bullets[i].transform.position.y < -5)
            {
                Destroy(bullets[i]);
                bullets.RemoveAt(i);
            }
        }
    }

    void Update()
    {

        tank.position += tank.right * Time.deltaTime * variables.tankSpeed * Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = new GameObject();
            var sprbullet = bullet.AddComponent<SpriteRenderer>();
            sprbullet.sprite = variables.testSprite;
            sprbullet.color = Color.red;
            bullet.transform.position = tank.position;

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePos - (Vector2)tank.position).normalized;

            var rb = bullet.AddComponent<Rigidbody2D>();
            rb.gravityScale = 1;
            rb.linearVelocity = direction * variables.bulletSpeed;

            bullets.Add(bullet);
            testFallingBullets();

        }
    }




}
