using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Item : MonoBehaviour {

	public string name;
	public string description;
	public Sprite icon;

	public int position;

	protected void Start () {
		
	}

	protected void Update () {

	}

	abstract public void use ();
}
