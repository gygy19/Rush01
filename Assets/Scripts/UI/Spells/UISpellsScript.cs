using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISpellsScript : MonoBehaviour {

	public ButtonScript exitButton;
	public GameObject[] contentObjects;
	public UISpellScript[] spellsSlots;
	public Text spellsPoints;
	public bool visible = false;

	private RPGPlayer player;

	// Use this for initialization
	void Start () {
		this.player = GameObject.Find ("Player").GetComponent<RPGPlayer>();
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
		foreach (Spell spell in player.spells) {
			bool contain = false;
			foreach (UISpellScript spellSlot in spellsSlots) {
				if (spellSlot.spell == spell) {
					contain = true;
					break;
				}
			}
			if (contain == false) {
				addSpell (spell);
			}
		}
		spellsPoints.text = "" + player.getSpellPoints ();
	}

	public void setVisible(bool visible) {
		this.visible = visible;
		foreach (GameObject o in contentObjects) {
			o.SetActive (visible);
		}
	}

	public void levelUpSpell(Spell spell) {
		spell.up ();
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
