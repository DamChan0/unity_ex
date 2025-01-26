using UnityEngine;
using UnityEngine.AI;

public class Movement3D : MonoBehaviour
{
	private Vector3 currentPosition
	{
		get { return transform.position; }
		set { transform.position = value; }
	}

	[SerializeField]
	// public float speed = 12;
	private Vector3 moveDirection;
	private CharacterController controller;
	private float gravity = -9.81f;

	private float x;
	private float z;

	public float gravityP
	{
		get { return gravity; }
		set { gravity = value; }
	}
	[SerializeField]

	// private Transform cameraTransform;
	private PlayerProperty playerProperty;


	private void Awake()
	{
		controller = GetComponent<CharacterController>();
		playerProperty = GetComponent<PlayerProperty>();

		// cameraControll = GetComponent<CameraControll>();

	}
	private void Update()
	{
		x = Input.GetAxis("Horizontal");
		z = Input.GetAxis("Vertical");

		if (!controller.isGrounded)
		{
			moveDirection.y += gravity * Time.deltaTime;
		}

	}

	public Vector3 MoveDirection()
	{
		Vector3 moveTo = new Vector3(x, moveDirection.y, z);
		return moveTo;
	}

	public void JumpTo(float jumpForce)
	{
		moveDirection.y = jumpForce;
	}
}

