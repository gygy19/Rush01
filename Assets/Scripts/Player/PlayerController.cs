﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {

	public Camera 			Camera;
	private NavMeshAgent	Agent;
	bool					isMooving;
	public bool 			lockedCamera;

	void Start () {
		Camera = GameObject.Find ("Main Camera").GetComponent<Camera> ();
		Agent = GetComponent<NavMeshAgent> ();
		isMooving = false;
		lockedCamera = false;
		setDefaultCameraPostion ();
	}

	void setDefaultCameraPostion()
	{
		Camera.transform.localPosition = new Vector3 (66f, 64f, 189f);
		Camera.transform.localRotation = new Quaternion (0.5f, 0.0f, 0.01f, 0.9f);
	}

	Vector3 GetMousePosition()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit[] hits = Physics.RaycastAll (ray);
		foreach (RaycastHit hitInfo in hits)
		{
			if (hitInfo.collider.gameObject.name == "Terrain")
				return (hitInfo.point); 
		}
		return this.transform.position;
	}

	void catchMovement()
	{
		if (Input.GetMouseButtonDown(MouseClickEnum.RIGHT_CLICK)) {
			Vector3 position = GetMousePosition ();
			if (position.x != 0 && position.y != 0 && position.z != 0) {
				Agent.SetDestination (position);
				GetComponent<Animator> ().SetFloat (MovementEnum.MOVEMENT_FORWARD, 1);
				isMooving = true;
			}
		}
	}
		
	void StopMovement()
	{
		Agent.velocity = Vector3.zero;
		Agent.ResetPath();
		isMooving = false;
		GetComponent<Animator> ().SetFloat (MovementEnum.MOVEMENT_FORWARD, 0);
	}

	void followCamera()
	{
		if (!lockedCamera) {
			Camera.transform.position = new Vector3 (this.transform.position.x, Camera.transform.position.y, Camera.transform.position.z);
		} else { 
			Camera.transform.position = new Vector3 (this.transform.position.x, Camera.transform.position.y, this.transform.position.z - 20f);
		}
	}

	void Update () {
		catchMovement ();
		if (Agent.remainingDistance <= 3f && Agent.remainingDistance != 0) {
			StopMovement ();
		}
		followCamera ();
	}
}
