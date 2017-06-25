using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISpellsScript : MonoBehaviour {

	public ButtonScript exitButton;
	public GameObject[] contentObjects;
	public UISpellScript[] spellsSlots;
	public Text spellsPoints;

	public Text spellSelectedName;
	public Text spellSelectedLevel;
	public Text spellSelectedDescription;

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
		if (player.spells.Count > 0) {
			selectSpell (player.spells[0]);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (exitButton.isSelected) {
			this.player.GetComponent<PlayerController> ().pauseGame = false;
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

	public void selectSpell(Spell spell) {
		spellSelectedName.text = spell.name;
		spellSelectedLevel.text = "" + spell.getLevel ();
		spellSelectedDescription.text = "" +
			"Damages   : " + spell.getValue() + "\n" +
			"Mana cost : " + spell.mana + "\n" +
			"Heal      : ";
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
