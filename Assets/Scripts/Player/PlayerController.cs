using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {

	public Camera 			Camera;
	public NavMeshAgent		Agent;
	bool					isMooving;
	public bool 			lockedCamera;

	void Start () {
		Camera = GameObject.Find ("Main Camera").GetComponent<Camera> ();
		Agent = GetComponent<NavMeshAgent> ();
		isMooving = false;
		lockedCamera = false;
	}

	Vector3 GetMousePosition()
	{
		RaycastHit hitInfo;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Physics.Raycast (ray, out hitInfo);
		return (hitInfo.point);
	}

	void catchMovement()
	{
		if (Input.GetMouseButtonDown(MouseClickEnum.RIGHT_CLICK)) {
			Vector3 position = GetMousePosition ();
			if (position.x != 0 && position.y != 0 && position.z != 0) {
				Agent.SetDestination (position);
				GetComponent<Animator> ().SetFloat (PlayerMovementEnum.MOVEMENT_FORWARD, 1);
				isMooving = true;
			}
		}
	}
		
	void StopMovement()
	{
		Agent.velocity = Vector3.zero;
		Agent.ResetPath();
		isMooving = false;
		GetComponent<Animator> ().SetFloat (PlayerMovementEnum.MOVEMENT_FORWARD, 0);
	}

	void followCamera()
	{
		if (!lockedCamera) {
			Camera.transform.position = new Vector3 (this.transform.position.x, Camera.transform.position.y, Camera.transform.position.z);
		} else { 
			Camera.transform.position = new Vector3 (this.transform.position.x, Camera.transform.position.y, this.transform.position.z - 20f);
		}
	}

	// Update is called once per frame
	void Update () {
		catchMovement ();
		if (Agent.remainingDistance <= 2f && Agent.remainingDistance != 0) {
			StopMovement ();
		}
		followCamera ();
		//Agent.
		/*if (Input.GetMouseButtonUp(0))
			GetComponent<Animator> ().SetFloat ("Forward", 0);
		
		if (Input.GetKey(KeyCode.A))
			GetComponent<Animator> ().SetBool ("Attack", true);

		if (Input.GetKeyDown(KeyCode.C))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray))
				Instantiate(moveCursor, transform.position, transform.rotation);
		}*/
	}
}
