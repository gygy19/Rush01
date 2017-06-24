﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

	private PlayerController	playerController;
	private NavMeshAgent		Agent;
	public	bool 				isFollowing;
	public	Vector3 			followingPosition;
	public	float				speed;

	void Start ()
	{
		this.playerController = GameObject.Find ("Player").GetComponent<PlayerController> ();
		this.Agent = GetComponent<NavMeshAgent> ();
		this.isFollowing = false;
	}

	void FollowPlayer()
	{
		this.followingPosition = this.playerController.transform.position;
		this.Agent.SetDestination (this.playerController.transform.position);
		this.isFollowing = true;
		GetComponent<Animator> ().SetFloat (MovementEnum.MOVEMENT_FORWARD, speed);
	}

	void UnFollowPlayer()
	{
		Agent.velocity = Vector3.zero;
		Agent.ResetPath();
		GetComponent<Animator> ().SetFloat (MovementEnum.MOVEMENT_FORWARD, 0);
		this.isFollowing = false;
	}

	void rotateToPlayer()
	{
		Vector3 targetDir = playerController.transform.position - transform.position;
		float step = 2f * Time.deltaTime;
		Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
		Debug.DrawRay(transform.position, newDir, Color.red);
		transform.rotation = Quaternion.LookRotation(newDir);
	}

	void attackPlayer() 
	{
		rotateToPlayer ();
		GetComponent<Animator> ().SetBool (MovementEnum.MOVEMENT_ATTACK, true);
	}

	void isAroundPlayer()
	{
		if (this.Agent.remainingDistance <= 4f) {
			attackPlayer ();
		}
		else
			GetComponent<Animator> ().SetBool (MovementEnum.MOVEMENT_ATTACK, false);
	}

	void Update ()
	{
		if (isFollowing) {
			isAroundPlayer ();
			if (this.playerController.transform.position.x != followingPosition.x || this.playerController.transform.position.y != followingPosition.y || this.playerController.transform.position.z != followingPosition.z) {
				FollowPlayer ();
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.name == "Player" && !this.isFollowing)
			FollowPlayer ();
	}

	void OnTriggerExit(Collider other)
	{
		if (other.name == "Player" && this.isFollowing)
			UnFollowPlayer ();
	}
}