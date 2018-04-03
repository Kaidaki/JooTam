using UnityEngine;
using System.Collections;

public class CharMovingOpenField : MonoBehaviour
{
	public float moveSpeed = 6.0f;
	public Vector3 moveVector { get; set; }
	public static float globalGravity = -9.81f;

	[SerializeField] VirtualJoystickModule joystick;
	[SerializeField] Rigidbody rigidbodyCtrl;
	[SerializeField] Animator animCtrl;

	//checker
	[SerializeField] Vector3 testVector;
	[SerializeField] float gravityScale = 1.0f;
	[SerializeField] float dirX;
	[SerializeField] float dirZ;
	[SerializeField] float veloMagnit;


	// Update is called once per frame
	void Update()
	{
		veloMagnit = rigidbodyCtrl.velocity.magnitude;
		moveVector = poolInput();
		animCtrl.SetFloat("speed", veloMagnit);

		move();
	}

	void FixedUpdate()
	{		
		Vector3 gravity = globalGravity * gravityScale * Vector3.up;
		rigidbodyCtrl.AddForce(gravity, ForceMode.Acceleration);
	}

	void move()
	{
		rigidbodyCtrl.AddForce(moveVector * moveSpeed, ForceMode.Force);
		testVector = moveVector;
	}

	Vector3 poolInput()
	{
		Vector3 dir = Vector3.zero;

		dir.x = joystick.horizontal();
		dirX = dir.x;
		dir.z = joystick.vertical();
		dirZ = dir.z;

		if (dir.magnitude > 1)
			dir.Normalize();

		return dir;
	}
}
