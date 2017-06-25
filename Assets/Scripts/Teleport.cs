using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour {

	public string SceneName;

	// Use this for initialization
	void Start () {
		if (SceneName == "")
			Debug.Log ("Miss SceneName on Teleport");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "Player") {
			other.gameObject.GetComponent<PlayerController> ().StopMovement ();
				DontDestroyOnLoad(other.gameObject);
				SceneManager.LoadScene (SceneName);

		}
	}
}
