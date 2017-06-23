using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {

	// Use this for initialization

	private GameObject		destination;

	public GameObject		moveCursor;

	public Camera 			Camera;

	public Vector3			WhereIGo;

	void Start () {
		destination = GameObject.Find ("ToGo");
		Camera = GameObject.Find ("Main Camera").GetComponent<Camera>();
	}


	Vector3 GetMousePosition()
	{
		RaycastHit hitInfo;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Physics.Raycast (ray, out hitInfo);
		return (hitInfo.point);
	}


	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			Vector3 position = GetMousePosition ();
				//destination.transform.localPosition = Camera.ScreenToWorldPoint (Input.mousePosition);
			if (position.x != 0 && position.y != 0 && position.z != 0) {
				GetComponent<NavMeshAgent> ().SetDestination (position); 
				GetComponent<Animator> ().SetFloat ("Forward", 1); 
			}
		}

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
