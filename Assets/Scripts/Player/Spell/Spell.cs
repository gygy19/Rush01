using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public abstract class Spell : MonoBehaviour {

	public string name;
	public Image icon;
	public int mana;

	protected void Start () {
	}
	
	protected void Update () {
		
	}

	abstract public void use ();
}
