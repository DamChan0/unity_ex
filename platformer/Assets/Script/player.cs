using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

public class player : MonoBehaviour
{
    public float moveSpeed = 3;
    private MoveMent2D moveMent2D;
    // moveMent2D는 MoveMent2D.cs에 있는 클래스
    private KeyCode fireKey = KeyCode.Space;

    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Vector3 bulletDirection = Vector3.right;
    private Rigidbody2D rigid2D;
    private float JumpOn = 0;
    private const float longJumpThreshold = 2f; // 1 second
    private float spaceKeyPressTime = 0f;
    private void Awake()
    {
        moveMent2D = GetComponent<MoveMent2D>();
        // GetComponent는 이 스크립트가 붙어있는 오브젝트의 컴포넌트를 가져온다.
        // 즉 player에는 MOveMent2D가 붙어있어야 한다.

        rigid2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        moveMent2D.Move(x);
        // JumpOn = Input.GetKeyDown(key: KeyCode.Space) ? 1 : 0;

        if (Input.GetKey(KeyCode.Space))
        {
            spaceKeyPressTime += Time.deltaTime;
            Debug.Log(spaceKeyPressTime);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            if (spaceKeyPressTime >= longJumpThreshold)
            {
                moveMent2D.Jump();
                moveMent2D.isLongJump = true;
            }
            else
            {
                moveMent2D.Jump();
                moveMent2D.isLongJump = false;
            }
            spaceKeyPressTime = 0f; // Reset the timer

        }

        // if (x != 0 || y != 0)
        // {
        //     bulletDirection = new Vector3(x, y, 0).normalized;
        // }

        // rigid2D.velocity = new Vector3(x, y, 0) * moveSpeed;

        // if (Input.GetKeyDown(fireKey))
        // {
        //     attack();
        // }
    }

    void attack()
    {
        if (Input.GetKeyDown(fireKey))
        {
            GameObject bulletobj = Instantiate(bullet, transform.position, quaternion.identity);
            bulletobj.GetComponent<projectile>().setUp(bulletDirection);
            // bullet.GetComponent<SpriteRenderer>().color = Color

        }
    }

}
