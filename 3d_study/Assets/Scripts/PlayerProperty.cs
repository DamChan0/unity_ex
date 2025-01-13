using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// set player's properties
public class PlayerProperty : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 8f;
    public float jumpForce = 2f;

    private Movement3D movement3D;
    [SerializeField]

    // private CameraControll cameraControll;
    private CharacterController controller;

    private Vector3 currentPosition
    {
        get { return transform.position; }
        set { transform.position = value; }
    }
    private void Awake()
    {
        movement3D = GetComponent<Movement3D>();
        controller = GetComponent<CharacterController>();
        // cameraControll = GetComponentInChildren<CameraControll>();

    }

    private void Update()
    {
        controller.Move(movement3D.MoveDirection() * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            movement3D.JumpTo(jumpForce);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 16f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 8f;
        }
        // fovX = Input.GetAxis("Mouse X");
        // fovY = Input.GetAxis("Mouse Y");

        // cameraControll.cametaRotate(fovX, fovY);

    }



}
