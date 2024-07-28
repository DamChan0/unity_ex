using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

public class movemnob : MonoBehaviour
{
    public float moveSpeed = 3;

    private Vector3 moveDirection = Vector3.zero;

    private Rigidbody2D rigid2D;

    public void setUp(Vector3 moveDirection)
    {
        this.moveDirection = moveDirection;
    }
    private void Awake()
    {
        // transform.position = transform.position + new Vector3(1, 0, 0) * 1;
        rigid2D = GetComponent<Rigidbody2D>();
        // trasform.position은 내 위치
    }

    private void Update()
    {
        transform.position += moveDirection * Time.deltaTime * moveSpeed;
    }

}
