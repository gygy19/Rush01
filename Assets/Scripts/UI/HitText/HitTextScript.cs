using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitTextScript : MonoBehaviour {

	private Text text;
	private int maxPoliceSize = 30;
	private int minPoliceSize = 0;
	private float currentSize = 30;

	// Use this for initialization
	void Start () {
		text = this.GetComponent<Text> ();
		//GameObject.DestroyObject(this.gameObject, 2.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (currentSize <= minPoliceSize) {
			GameObject.Destroy (this.gameObject);
			return;
		}
		currentSize -= 0.05f;
		//setSizeToFont ((int)currentSize);
		this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y + 0.1f, this.transform.position.z);
		//this.transform.localScale = new Vector3 (this.transform.localScale.x - 0.03f, this.transform.localScale.y - 0.03f, this.transform.localScale.z);
	}

	private void setSizeToFont(int size) {
		this.text.fontSize = size;
	}

	public void initialize(float damage) {
		this.text.text = "" + damage;
	}
}
