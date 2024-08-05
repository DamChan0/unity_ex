using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMent2D : MonoBehaviour
{
    [HideInInspector]
    public bool isLongJump = false;
    public float moveSpeed = 3;
    public float jumpPower = 2;




    private Rigidbody2D rigid2D;

    private CapsuleCollider2D capsuleCollider2D;
    private Vector3 footPosition;
    bool isJumping = false;
    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    private void FixedUpdate()
    {
        CheckLongJump();
        isJumping = CheckJumping();
    }

    public void Move(float x)
    {
        rigid2D.velocity = new Vector3(x * moveSpeed, rigid2D.velocity.y, 0);
    }

    public void Jump()
    {
        if (isJumping)
            rigid2D.velocity = Vector2.up * jumpPower;
    }

    private bool CheckLongJump()
    {
        if (isLongJump && rigid2D.velocity.y > 0)
        {
            rigid2D.gravityScale = 0.5f;
            Debug.Log("LongJump");
            return true;
        }
        else
        {
            rigid2D.gravityScale = 1f;
            Debug.Log("NormalJump");
            return false;
        }
    }

    private bool CheckJumping()
    {
        bool isGrounded;
        Bounds bounds = capsuleCollider2D.bounds;
        footPosition = new Vector3(bounds.center.x, bounds.min.y, bounds.center.z);
        isGrounded = Physics2D.OverlapCircle(footPosition, 0.1f, LayerMask.GetMask("Ground"));

        return isGrounded;

    }
    // Start is called before the first frame update

}
