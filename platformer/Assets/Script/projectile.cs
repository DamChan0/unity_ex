using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

public class projectile : MonoBehaviour
{
    public float moveSpeed = 3;

    private Vector3 moveDirection = Vector3.zero;

    private Rigidbody2D rigid2D;
    // float maxX = 10.0f; float maxY = 10.0f;

    Vector3 rightEdgeWorldPos;
    Vector3 topEdgeWorldPos;
    public void setUp(Vector3 bulletDirection)
    {
        this.moveDirection = bulletDirection;
    }
    private void Awake()
    {
        // transform.position = transform.position + new Vector3(1, 0, 0) * 1;
        rigid2D = GetComponent<Rigidbody2D>();
        Camera mainCamera = Camera.main;
        topEdgeWorldPos = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 1, mainCamera.nearClipPlane));
        rightEdgeWorldPos = mainCamera.ViewportToWorldPoint(new Vector3(1, 0.5f, mainCamera.nearClipPlane));
        // trasform.position은 내 위치
    }

    private void Update()
    {
        gameObject.transform.position += moveDirection * Time.deltaTime * moveSpeed;
        if (gameObject.transform.position.x > rightEdgeWorldPos.x
        || gameObject.transform.position.x < -rightEdgeWorldPos.x
        || gameObject.transform.position.y > topEdgeWorldPos.y
        || gameObject.transform.position.y < -topEdgeWorldPos.y
        )
        {
            Destroy(gameObject);
        }
    }

}
