using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITransporteurScript : MonoBehaviour {

	public GameObject[] contentObjects;
	public bool visible = false;

	// Use this for initialization
	void Start () {
		foreach (GameObject o in contentObjects) {
			o.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void setVisible(bool visible) {
		this.visible = visible;
		foreach (GameObject o in contentObjects) {
			o.SetActive (visible);
		}
	}
}
