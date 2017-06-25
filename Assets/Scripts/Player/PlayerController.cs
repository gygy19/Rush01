using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public Camera 			Camera;
	private NavMeshAgent	Agent;
	bool					isMooving;
	public bool 			lockedCamera;
	public RPGPlayer		RPGPlayer;
	public bool				pauseGame;
	public bool				isDying;
	public float			dieTime;
	public float			meleeTime;
	public float			attackSpeed;
	void Start () {
		Camera = GameObject.Find ("Main Camera").GetComponent<Camera> ();
		Agent = GetComponent<NavMeshAgent> ();
		RPGPlayer = GetComponent<RPGPlayer> ();
		isMooving = false;
		//lockedCamera = false;
		setDefaultCameraPostion ();
		pauseGame = false;
	}

	public void Die () {
		RPGPlayer.setHp (0);
		dieTime = Time.fixedTime;
		pauseGame = true;
		isDying = true;
		GetComponent<Animator> ().SetBool (MovementEnum.MOVEMENT_DEAD, true);
	}

	void setDefaultCameraPostion()
	{
		Camera.transform.localPosition = new Vector3 (16f, 66f, 89f);
		Camera.transform.localRotation = new Quaternion (0.5f, 0.0f, 0.01f, 0.9f);
	}

	void rotateToMouse()
	{
		Vector3 targetDir = Constants.GetMousePosition () - transform.position;
		float step = 100f * Time.deltaTime;
		Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
		Debug.DrawRay(transform.position, newDir, Color.red);
		transform.rotation = Quaternion.LookRotation(newDir);
	}

	void meleeAttack()
	{
		float diff = Time.fixedTime - meleeTime;
		if (diff > attackSpeed) {
			Collider[] hitColliders = Physics.OverlapSphere (this.transform.position, 1f);
			int i = 0;
			while (i < hitColliders.Length) {
				if (hitColliders [i].gameObject.tag == Constants.ENEMY_TAG) {
					EnemyController controller = hitColliders [i].gameObject.GetComponent<EnemyController> ();
					if (controller.isDying == false)
						controller.takeDamage (RPGPlayer.getDamage ());
				}
				i++;
			}
			meleeTime = Time.fixedTime;
		}
	}

	void takeItem()
	{
		Collider[] hitColliders = Physics.OverlapSphere (this.transform.position, 1f);
		int i = 0;
		while (i < hitColliders.Length) {
				if (hitColliders [i].gameObject.tag == Constants.ITEM_TAG) {
					Item it = hitColliders [i].gameObject.GetComponent<Item> ();
					it.take ();
					RPGPlayer.Player.GetComponent<RPGPlayer> ().addItemToInventory (it);
					break;
				}
			i++;
		}
	}

	void catchMovement()
	{
		if (Input.GetMouseButton (MouseClickEnum.RIGHT_CLICK)) {
			rotateToMouse ();
			Vector3 position = Constants.GetMousePosition ();
			if (position.x != 0 && position.y != 0 && position.z != 0) {
				Agent.SetDestination (position);
				GetComponent<Animator> ().SetFloat (MovementEnum.MOVEMENT_FORWARD, 1);
				isMooving = true;
			}
		} else if (Input.GetKey (KeyCode.Q)) {
			meleeAttack ();
			GetComponent<Animator> ().SetBool (MovementEnum.MOVEMENT_ATTACK, true);
		} else {
			GetComponent<Animator> ().SetBool (MovementEnum.MOVEMENT_ATTACK, false);
		}
	}

	public void StopMovement()
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

	void endGame()
	{
		//openEndMenu ();
		Debug.Log ("Game over !");
	}

	void onPauseGame()
	{
		StopMovement ();
		if (isDying) {
			float diff = Time.fixedTime - dieTime;
			if (diff > 3f) {
				GetComponent<Animator> ().SetBool (MovementEnum.MOVEMENT_DEAD, false);
				isDying = false;
				endGame ();
			}
		}
	}

	void Update () {
		if (pauseGame) {
			onPauseGame ();
			return;
		}
		if (Input.GetKeyDown (KeyCode.E))
			this.takeItem ();
		catchMovement ();
		if (Agent.remainingDistance <= 3f && Agent.remainingDistance != 0) {
			StopMovement ();
		}
		followCamera ();
	}
}
