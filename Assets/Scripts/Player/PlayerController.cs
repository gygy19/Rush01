using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {

	public Camera 			Camera;
	public NavMeshAgent		Agent;
	bool					isMooving;

	void Start () {
		Camera = GameObject.Find ("Main Camera").GetComponent<Camera> ();
		Agent = GetComponent<NavMeshAgent> ();
		isMooving = false;
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
				GetComponent<NavMeshAgent> ().SetDestination (position);
				GetComponent<Animator> ().SetFloat ("Forward", 1);
				isMooving = true;
			}
		}
	}

	void StopMovement()
	{
		isMooving = false;
		Debug.Log ("Stopped");
	}

	void followCamera()
	{
		Camera.transform.position = new Vector3 (this.transform.position.x, Camera.transform.position.y, Camera.transform.position.z);
	}

	// Update is called once per frame
	void Update () {
		catchMovement ();
		if (Agent.remainingDistance <= 4f && Agent.remainingDistance != 0) {
			StopMovement ();
			Debug.Log (Agent.remainingDistance);
		}
		//StopMovement ();
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
