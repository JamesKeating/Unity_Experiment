using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class PlayerController : MonoBehaviour {

	Rigidbody player;
	Camera viewCamera;
	
	void Start () {
		player = GetComponent<Rigidbody> ();
		viewCamera = Camera.main;
	}
	
	public void MovePlayer() {
		int moveSpeed = 5;
		Vector3 moveInput = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));
		Vector3 moveVelocity = moveInput.normalized * moveSpeed;
		player.MovePosition (player.position + moveVelocity * Time.fixedDeltaTime);
	}
	
	public void LookAtMouse() {
		Ray ray = viewCamera.ScreenPointToRay (Input.mousePosition);
		Plane groundPlane = new Plane (Vector3.up, Vector3.zero);
		float rayDistance;
		
		if (groundPlane.Raycast(ray,out rayDistance)) {
			Vector3 point = ray.GetPoint(rayDistance);
			Vector3 heightCorrectedPoint = new Vector3 (point.x, transform.position.y, point.z);
			transform.LookAt (heightCorrectedPoint);
		}

	
	}
	
	public void FixedUpdate() {
		MovePlayer();
		LookAtMouse();
	}
}