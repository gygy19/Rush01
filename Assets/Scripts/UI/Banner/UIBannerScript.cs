using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIBannerScript : MonoBehaviour{

	public ButtonScript[] cases;

	public UICaracteristiquesScript caracteristiquePanel;
	public UISpellsScript spellsPanel;
	public UIInventoryScript inventoryPanel;

	public ProgressBarScript manaBarre;
	public ProgressBarScript lifeBarre;

	private RPGPlayer player;

	// Use this for initialization
	void Start () {
		this.player = GameObject.Find ("Player").GetComponent<RPGPlayer>();
	}
	
	// Update is called once per frame
	void Update () {
		_hookClickEntry ();
	}

	private void _hookClickEntry() {
		lifeBarre.UpdatePurcent ((float)(100 * player.getHp() / player.getMaxHp()));
		manaBarre.UpdatePurcent ((float)(100 * player.getMana() / player.getMaxMana()));
	}

	public void OnOpenUICarac() {
		caracteristiquePanel.setVisible (!caracteristiquePanel.visible);
	}

	public void OnOpenUIInventory() {
		inventoryPanel.setVisible (!inventoryPanel.visible);
	}

	public void OnOpenUISpells() {
		spellsPanel.setVisible (!spellsPanel.visible);
	}

	public void OnclickCase(ButtonScript button) {
		
	}

}
