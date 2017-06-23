using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGPlayer : GameUnit {

	// Use this for initialization
	void Start () {
		base.Start ();
	}
	
	// Update is called once per frame
	void Update () {
		base.Update ();
		if (Input.GetKey(KeyCode.A))
			this.addExp(10);
	}
}
