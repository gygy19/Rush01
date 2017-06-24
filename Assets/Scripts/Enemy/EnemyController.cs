using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

	private PlayerController	playerController;
	private NavMeshAgent		Agent;
	public	bool 				isFollowing;

	void Start ()
	{
		this.playerController = GameObject.Find ("Player").GetComponent<PlayerController> ();
		this.Agent = GetComponent<NavMeshAgent> ();
		this.isFollowing = false;
	}

	void FollowPlayer()
	{
		this.Agent.SetDestination (this.playerController.transform.position);
		this.isFollowing = true;
		Debug.Log ("I'm going to the player position !");
		GetComponent<Animator> ().SetFloat (MovementEnum.MOVEMENT_FORWARD, 1);
	}

	void Update ()
	{
		if (!this.isFollowing) {
			FollowPlayer ();
		}
	}
}
