using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rePosition : MonoBehaviour
{


    // private void OnTriggerExit2D(Collider2D other)
    // {
    //     if (other.tag != "Area")
    //     {
    //         return;
    //     }
    //     // if (!other.CompareTag("Area"))

    //     //     return;


    //     Vector3 playerPos = GameManager.instance.player.transform.position;
    //     Vector3 myPos = transform.position;
    //     float diffX = Mathf.Abs(playerPos.x - myPos.x);
    //     float diffY = Mathf.Abs(playerPos.y - myPos.y);

    //     Vector3 playerDirection = GameManager.instance.player.moveInput; // moveIN
    //     float dirX = playerDirection.x < 0 ? -1f : 1f;
    //     float dirY = playerDirection.y < 0 ? -1f : 1f;

    //     switch (transform.tag)

    //     {
    //         case "Ground":
    //             if (diffX > diffY)
    //             {
    //                 transform.Translate(Vector3.right * dirX * 40);
    //             }
    //             else if (diffX < diffY)
    //             {
    //                 transform.Translate(Vector3.up * dirY * 40);
    //             }
    //             break;
    //         case "Enemy":
    //             break;

    //         case "Area":
    //             break;
    //     }


    // }

}