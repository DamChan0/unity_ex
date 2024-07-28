using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

public class player : MonoBehaviour
{
    public float moveSpeed = 3;
    private KeyCode fireKey = KeyCode.Space;

    [SerializeField]
    private GameObject bullet;

    private Vector3 moveDirection = Vector3.zero;
    private Vector3 bulletDirection = Vector3.right;
    private Rigidbody2D rigid2D;
    private void Awake()
    {
        // transform.position = transform.position + new Vector3(1, 0, 0) * 1;
        rigid2D = GetComponent<Rigidbody2D>();
        // trasform.position은 내 위치
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // moveDirection = new Vector3(-x, -y, 0);
        // transform.position += moveDirection * Time.deltaTime * moveSpeed;
        if (x != 0 || y != 0)
        {
            bulletDirection = new Vector3(x, y, 0);
        }

        rigid2D.velocity = new Vector3(x, y, 0) * moveSpeed;

        if (Input.GetKeyDown(fireKey))
        {
            attack();
        }
    }

    void attack()
    {
        if (Input.GetKeyDown(fireKey))
        {
            GameObject bulletobj = Instantiate(bullet, transform.position, quaternion.identity);
            bulletobj.GetComponent<movemnob>().setUp(bulletDirection);
            bullet.GetComponent<SpriteRenderer>().color = Color.blue;

        }
    }

}
