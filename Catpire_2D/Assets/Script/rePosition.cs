using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class rePosition : MonoBehaviour
{
    SpriteRenderer sprite;
    private void Awake()
    {
    }
    // private bool isEnemyAlive = true;
    void OnTriggerExit2D(Collider2D collider)
    {

        if (!collider.CompareTag("Area"))
        {
            return;
        }

        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 myPos = transform.position;

        float diffX = Math.Abs(playerPos.x - myPos.x);
        float diffY = Math.Abs(playerPos.y - myPos.y);

        Vector3 playDirection = GameManager.instance.player.inputVector;
        float xDirection = playDirection.x < 0 ? -1 : 1;
        float yDirection = playDirection.y < 0 ? -1 : 1;

        switch (transform.tag)
        {
            case "Ground":
                if (diffX > diffY)
                {
                    transform.Translate(Vector3.right * xDirection * 40);
                }
                else if (diffY > diffX)
                {
                    transform.Translate(Vector3.up * yDirection * 40);
                }
                break;
            case "Enemy":
                if (collider.enabled)
                {
                    transform.Translate(playDirection * 20 + new Vector3(UnityEngine.Random.Range(-3f, 3f), UnityEngine.Random.Range(-3f, 3f), 0));
                }
                break;

        }



    }


}