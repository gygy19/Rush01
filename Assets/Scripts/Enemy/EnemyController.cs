﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {

	private PlayerController	playerController;
	private NavMeshAgent		Agent;
	public	bool 				isFollowing;
	public	Vector3 			followingPosition;
	public	float				moveSpeed;
	public	float				attackSpeed;
	public	RPGEnemy 			RPGEnemy;
	public	float				attackTime;
	public	int					experience;
	public List<GameObject> 	dropItems;


	public bool 				isDying;
	public float				dieTime;
	public GameObject			hitText;
	void Start ()
	{
		this.playerController = GameObject.Find ("Player").GetComponent<PlayerController> ();
		this.Agent = GetComponent<NavMeshAgent> ();
		this.RPGEnemy = GetComponent<RPGEnemy> ();
		this.isFollowing = false;
		this.isDying = false;

		IEnumerator routine = initializeData (1.0f);
		this.StartCoroutine (routine);
	}

	public IEnumerator initializeData(float waitTime)
	{
		while (true)
		{
			if (playerController.RPGPlayer != null) {
				RPGEnemy.setLevel (playerController.RPGPlayer.getLevel());
				break;
			}
			yield return new WaitForSeconds(waitTime);
		}
	}

	void FollowPlayer()
	{
		this.followingPosition = this.playerController.transform.position;
		this.Agent.SetDestination (this.playerController.transform.position);
		this.isFollowing = true;
		GetComponent<Animator> ().SetFloat (MovementEnum.MOVEMENT_FORWARD, moveSpeed);
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
		float diff = Time.fixedTime - attackTime;
		if (diff > attackSpeed) {
			GetComponent<Animator> ().SetBool (MovementEnum.MOVEMENT_ATTACK, true);
			RPGEnemy.Attack (playerController);
			attackTime = Time.fixedTime;
		}
		rotateToPlayer ();
	}

	void isAroundPlayer()
	{
		if (this.Agent.remainingDistance <= 4f) {
				attackPlayer ();
		} else {
			GetComponent<Animator> ().SetBool (MovementEnum.MOVEMENT_ATTACK, false);
		}
	}

	void OnPausedGame()
	{
		GetComponent<Animator> ().SetBool (MovementEnum.MOVEMENT_ATTACK, false);
		GetComponent<Animator> ().SetFloat (MovementEnum.MOVEMENT_FORWARD, 0);
		Agent.velocity = Vector3.zero;
		Agent.ResetPath();
	}

	void setAnimatorSpeed(int speed)
	{
		Animator animator = GetComponent<Animator> ();
		animator.speed = speed;
	}

	void Update ()
	{
		if (playerController.pauseGame) {
			OnPausedGame ();
			return;
		}
		if (isDying) {
			float diff = Time.fixedTime - this.dieTime;
			if (diff > 3f) {
				DropItems ();
				GameObject.DestroyObject (this.gameObject);
			}
		}
		else if (isFollowing) {
			setAnimatorSpeed (1);
			if (playerController.RPGPlayer.getHp () > 0) {
				isAroundPlayer ();
				if (this.playerController.transform.position.x != followingPosition.x || this.playerController.transform.position.y != followingPosition.y || this.playerController.transform.position.z != followingPosition.z) {
					FollowPlayer ();
				}
			} else {
				GetComponent<Animator> ().SetBool (MovementEnum.MOVEMENT_ATTACK, false);
			}
		} else {
			setAnimatorSpeed (5);
			this.followingPosition = this.playerController.transform.position;
			this.Agent.SetDestination (this.playerController.transform.position);
			GetComponent<Animator> ().SetFloat (MovementEnum.MOVEMENT_FORWARD, 0.1f);
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

	public void	DropItems()
	{
		int dropped = Random.Range (0, this.dropItems.Count);
		GameObject newDrop = GameObject.Instantiate (this.dropItems[dropped]);
		newDrop.transform.position = this.transform.position;
		Debug.Log ("The enemy dropped an item :" + newDrop.name);
	}

	public void Die()
	{
		this.UnFollowPlayer ();
		playerController.RPGPlayer.addExp (this.experience);
		GetComponent<Animator> ().SetBool (MovementEnum.MOVEMENT_DEAD, true);
		this.isDying = true;
		this.dieTime = Time.fixedTime;
		Debug.Log ("An enemy is dying ! Well played you won " + this.experience + " points of experience !");
		this.OnPausedGame ();
	}

	public void popCurrentHit(int valueDamage)
	{
		GameObject currentHit = GameObject.Instantiate (this.hitText);
		currentHit.GetComponent<Text>().text = " - " + valueDamage.ToString();
		currentHit.GetComponent<Text> ().fontSize = 30;

		currentHit.transform.SetParent(GameObject.Find ("Canvas").GetComponent<Canvas>().transform);
		currentHit.transform.position = new Vector3 (83.6f, 174.5f, 0f);
	}

	public void takeDamage(int value)
	{
		this.popCurrentHit (value);
		this.RPGEnemy.damage (value);
		if (this.RPGEnemy.getHp () <= 0) {
			this.Die ();	
		}
	}
}
