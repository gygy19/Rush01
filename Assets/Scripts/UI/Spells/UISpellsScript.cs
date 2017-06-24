using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISpellsScript : MonoBehaviour {

	public ButtonScript exitButton;
	public GameObject[] contentObjects;
	public UISpellScript[] spellsSlots;
	public bool visible = false;

	public RPGPlayer player;

	// Use this for initialization
	void Start () {
		foreach (Spell spell in player.spells) {
			addSpell (spell);
		}
		foreach (GameObject o in contentObjects) {
			o.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (exitButton.isSelected) {
			exitButton.isSelected = false;
			setVisible (false);
		}
	}

	public void setVisible(bool visible) {
		this.visible = visible;
		foreach (GameObject o in contentObjects) {
			o.SetActive (visible);
		}
	}

	public void levelUpSpell(Spell spell) {
		//TODO
	}

	public void addSpell(Spell spell) {
		foreach (UISpellScript spellSlot in spellsSlots) {
			if (spellSlot.spell == null) {
				spellSlot.addSpell (spell);
				break ;
			}
		}
	}

	public void removeSpell(Spell spell) {
		foreach (UISpellScript spellSlot in spellsSlots) {
			if (spellSlot.spell != null && spell == spellSlot.spell) {
				spellSlot.removeSpell();
				break ;
			}
		}
	}
}
