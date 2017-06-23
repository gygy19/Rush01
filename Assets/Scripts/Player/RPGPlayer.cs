using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGPlayer : GameUnit {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.A))
			this.addExp(10);
		Debug.Log (this.getLevel ());
	}
}
