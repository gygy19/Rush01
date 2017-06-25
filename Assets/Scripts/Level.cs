using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class Level : MonoBehaviour {

	public Transform start;

	private GameObject Player;
	private GameObject PlayerPrefab;


	// Use this for initialization
	void Start () {
		Player = GameObject.Find ("Player");

		/*
		IEnumerator routine = initializeData (1.0f);
		this.StartCoroutine (routine);
		*/

		PlayerPrefab = GameObject.Find ("PlayerPrefab");
		PlayerPrefab.SetActive (false);

		Player.AddComponent<NavMeshAgent> (PlayerPrefab.GetComponent<NavMeshAgent> ());

		GameObject.Destroy(PlayerPrefab.gameObject);

		PlayerController p = Player.GetComponent<PlayerController> ();
		print ("Level OnStart");
		print ("launch Player OnChangeScene");
		p.OnChangeScene ();
	}

	/*
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
	}*/
	
	// Update is called once per frame
	void Update () {
		
	}
}
