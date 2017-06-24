using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICaracteristiquesScript : MonoBehaviour {

	public ButtonScript exitButton;
	public GameObject[] contentObjects;
	public bool visible = false;

	public UIStatScript Level;
	public UIStatScript statsPoints;

	public UIStatScript Life;
	public UIStatScript Mana;
	public UIStatScript Strength;
	public UIStatScript Agility;
	public UIStatScript Intelligence;

	public RPGPlayer player;

	// Use this for initialization
	void Start () {
		foreach (GameObject o in contentObjects) {
			o.SetActive (false);
		}
		Mana.buttonUp.active = false;
		Life.buttonUp.active = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (exitButton.isSelected) {
			exitButton.isSelected = false;
			setVisible (false);
		}
		_updateStats ();
	}

	public void setVisible(bool visible) {
		this.visible = visible;
		foreach (GameObject o in contentObjects) {
			o.SetActive (visible);
		}
	}

	private void _updateStats() {
		Level.UpdateStats (player.getLevel());
		statsPoints.UpdateStats (10);
		Life.UpdateStats (player.getHp());
		Mana.UpdateStats (player.getMana());
		Strength.UpdateStats (player.getStr());
		Agility.UpdateStats (player.getAgi());
		Intelligence.UpdateStats (player.getIntel());
	}
}
