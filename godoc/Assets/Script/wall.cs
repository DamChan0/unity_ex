using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour
{
    [SerializeField]
    private GameObject moveObject;
    [SerializeField]
    private Vector3 moveDirection;
    private float moveSpeed;
    private Rigidbody2D rigid2D;
    // private SpriteRenderer spriteRenderer;d
    public Color color = Color.cyan;


    private void Awake()
    {
        moveSpeed = 5.0f;
        Physics.IgnoreLayerCollision(0, 3, true);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // moveObject 오브젝트의 색상을 검은색(Color.black)으로 설정한다
        //어떤 콜라이더와 trigger가 발생한건지 확인
        // Debug.Log("OnTriggerEnter2D called");
        moveObject.GetComponent<SpriteRenderer>().color = Color.black;
        rigid2D = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (moveObject != null)
        {
            moveObject.transform.position += moveDirection * moveSpeed * Time.deltaTime;
            Debug.Log("OnTriggerStay2D called");
            rigid2D.WakeUp();
        }
    }

    /// <summary>
    /// 충돌이 종료되는 순간 1회 호출
    /// </summary>
    private void OnTriggerExit2D(Collider2D collision)
    {
        moveObject.GetComponent<SpriteRenderer>().color = Color.white;

    }

}
