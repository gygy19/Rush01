using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISpellScript : MonoBehaviour {

	public Text name;
	public Text lblCountLevel;
	public SpellCaseButtonScript spellCase;
	public ButtonScript buttonLevelup;
	public bool active = false;
	public UISpellsScript spellPanel;

	public Spell spell;

	// Use this for initialization
	void Start () {
		this.gameObject.SetActive (active);
	}
	
	// Update is called once per frame
	void Update () {
		if (active != this.gameObject.active)
			this.gameObject.SetActive (active);

		if (spell != null) {
			lblCountLevel.text = "" + spell.getLevel ();
		}

		if (this.buttonLevelup.isSelected) {
			spellPanel.levelUpSpell (spell);
			this.buttonLevelup.isSelected = false;
		}
	}

	public void addSpell(Spell spell) {
		this.spell = spell;
		this.name.text = spell.name;
		//TODO
		//this.lblCountLevel.text
		spellCase.addSpell (spell);
		this.active = true;
		this.gameObject.SetActive (true);
	}

	public void removeSpell() {
		this.active = false;
		this.gameObject.SetActive (false);
		spellCase.removeSpell ();
		this.spell = null;
		this.name.text = "";
	}
}
