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
